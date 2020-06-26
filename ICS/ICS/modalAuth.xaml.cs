using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Security.Cryptography;
using System.IO;
using Xamarin.Forms.StyleSheets;
using System.Data;
using Newtonsoft.Json;
using System.Net;
using System.Linq.Expressions;

namespace ICS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class modalAuth : ContentPage
    {
        public class Users
        {
            public string id { get; set; }
            public string name { get; set; }
            public string phone { get; set; }
            public string isTeacher { get; set; }
            public string groupCode { get; set; }
        }
        public modalAuth()
        {                       
            InitializeComponent();
            loginBtn.Clicked += LoginBtn_Clicked;
            regBtn.Clicked += RegBtn_Clicked;
            phone.TextChanged += Phone_TextChanged;
        }

        private void Phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            errorInvalidUser.Text = e.NewTextValue;
        }

        private void RegBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new modalReg(), false);
        }

        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            String authPhone = phone.Text.Trim(new char[] {'-', '(', ')', ' '});
            String authPass = password.Text;
            try
            {
                WebRequest request = WebRequest.Create("https://projectobd.000webhostapp.com/functions/response.php");
                request.Method = "POST"; // для отправки используется метод Post
                                         // данные для отправки
                string data = "phone=" + authPhone + "&password=" + authPass;
                // преобразуем данные в массив байтов
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
                // устанавливаем тип содержимого - параметр ContentType
                request.ContentType = "application/x-www-form-urlencoded";
                // Устанавливаем заголовок Content-Length запроса - свойство ContentLength
                request.ContentLength = byteArray.Length;

                //записываем данные в поток запроса
                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }

                WebResponse response = await request.GetResponseAsync();
                string ResponseUser;
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        ResponseUser = reader.ReadToEnd();
                        
                    }
                }
                response.Close();

                //List <Users> ListUser = new List<Users>();
                if (ResponseUser != "[]" || ResponseUser != "Failure!" || ResponseUser != "SemiFailure!")
                {
                    var ListUser = JsonConvert.DeserializeObject<List<Users>>(ResponseUser);
                    for (int i = 0; i < ListUser.Count; i++)
                    {
                        Encoding ascii = Encoding.Default;
                        Encoding unicode = Encoding.Unicode;
                        byte[] unicodeBytes = unicode.GetBytes(ListUser[i].name);
                        byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);
                        char[] asciiChars = new char[ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
                        ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
                        string nameString = new string(asciiChars);
                        if (ResponseUser != "Failure!")
                        {
                            App.Current.Properties.Add("phone", authPhone);
                            App.Current.Properties.Add("password", authPass);
                            App.Current.Properties.Add("name", nameString);
                            Navigation.PopModalAsync();
                        }
                    }
                }
            }
            catch (Exception)
            {
                errorInvalidUser.Text = "Connection failed!";
            }
            
            
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        


    }
}
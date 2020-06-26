using System;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class modalReg : ContentPage
    {
        public class student
        {
            public string stuName { get; set; }//done
            public string stuGroup { get; set; }//done
            public string stuPhone { get; set; }//done
            public string stuPass{ get; set; }//done
            public string stuPassControl { get; set; }//done
        }
            
        public class teacher
        {
            public string tName { get; set; }//done
            public string tPhone { get; set; }//done
            public string tPass { get; set; }//done
            public string tPassControl { get; set; }//done
            public string tCodeWord { get; set; }//done

        }
        public bool personAgreement = false;
        public teacher thisTeacher = new teacher();
        public student thisStudent = new student();
        public modalReg()
        {
            InitializeComponent();
            regSwitch.Toggled += RegSwitch_Toggled;
            if (!regSwitch.IsToggled)
            {
                
                Entry nameEntry = new Entry()
                {
                    Placeholder = "Прізвище ім'я"
                };
                nameEntry.TextChanged += NameEntry_TextChanged;
                Label groupLabel = new Label()
                {
                    Text = "Група"
                };
                Picker groupPick = new Picker()
                {
                    Title = "Група"
                };
                
                groupPick.Items.Add("КІ-181");
                groupPick.Items.Add("КІ-182");
                groupPick.SelectedIndexChanged += GroupPick_SelectedIndexChanged;
                
                StackLayout groupStack = new StackLayout()
                {
                    Children = { groupLabel, groupPick },
                    Orientation = StackOrientation.Horizontal
                };
                Entry phone = new Entry()
                {
                    Placeholder = "Номер телефону +380",
                    
                    Keyboard = Keyboard.Telephone
                };
                phone.TextChanged += Phone_TextChanged;
                phone.Behaviors.Add(new MaskedBehavior() { Mask = "+38(XXX)-XX-XX-XXX" });
                Entry password = new Entry()
                {
                    Placeholder = "Пароль",
                    IsPassword = true
                };
                password.TextChanged += Password_TextChanged;
                Entry controlPass = new Entry()
                {
                    Placeholder = "Підтвердіть пароль",
                    IsPassword = true
                };
                controlPass.TextChanged += ControlPass_TextChanged;
                Label agreement = new Label()
                {
                    Text = "Я погоджуюсь на обробку персональних даних"
                };
                CheckBox agreementCheck = new CheckBox()
                {
                    IsChecked = false
                };
                agreementCheck.CheckedChanged += AgreementCheck_CheckedChanged;
                StackLayout agreementStack = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = {agreement, agreementCheck }
                };
                Button backToLoginBtn = new Button()
                {
                    HeightRequest = 30,
                    Padding = 2,
                    ClassId = "authButton",
                    Text = "Назад",
                    CornerRadius = 31,
                    BackgroundColor = Color.FromHex("#88B1DE")
                };
                backToLoginBtn.Clicked += BackToLoginBtn_Clicked;
                Button registerBtn = new Button()
                {
                    HeightRequest = 30,
                    Padding = 2,
                    ClassId = "authButton",
                    Text = "Зареєструватися",
                    CornerRadius = 31,
                    BackgroundColor = Color.FromHex("#88B1DE")
                };
                registerBtn.Clicked += RegisterBtn_Clicked;
                StackLayout navigationBtns = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = { backToLoginBtn, registerBtn },
                    HorizontalOptions = LayoutOptions.CenterAndExpand
                };
                StackLayout studendOrTeacher = new StackLayout()
                {
                    Orientation = StackOrientation.Vertical,
                    Children = {nameEntry, groupStack, phone, password, controlPass, agreementStack, navigationBtns}
                };
                regLayout.Children.Add(studendOrTeacher);
            }
        }

        private void AgreementCheck_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            personAgreement = e.Value;
        }

        private void RegSwitch_Toggled(object sender, ToggledEventArgs e)
        {            
            if (regSwitch.IsToggled)
            {
                regLayout.Children.RemoveAt(3);
                Entry nameEntry = new Entry()
                {
                    Placeholder = "Прізвище ім'я"
                };
                nameEntry.TextChanged += NameEntry_TextChanged;
                Entry phone = new Entry()
                {
                    Placeholder = "Номер телефону +380",

                    Keyboard = Keyboard.Telephone
                };
                phone.TextChanged += Phone_TextChanged;
                phone.Behaviors.Add(new MaskedBehavior() { Mask = "+38(XXX)-XX-XX-XXX" });
                Entry password = new Entry()
                {
                    Placeholder = "Пароль",
                    IsPassword = true
                };
                password.TextChanged += Password_TextChanged;
                Entry controlPass = new Entry()
                {
                    Placeholder = "Підтвердіть пароль",
                    IsPassword = true
                };
                controlPass.TextChanged += ControlPass_TextChanged;
                Entry codeWord = new Entry()
                {
                    Placeholder = "Кодове слово",
                    IsPassword = false
                };
                codeWord.TextChanged += CodeWord_TextChanged;
                Label agreement = new Label()
                {
                    Text = "Я погоджуюсь на обробку персональних даних"
                };
                CheckBox agreementCheck = new CheckBox()
                {
                    IsChecked = false
                };
                agreementCheck.CheckedChanged += AgreementCheck_CheckedChanged;
                StackLayout agreementStack = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = { agreement, agreementCheck }
                };
                Button backToLoginBtn = new Button()
                {
                    HeightRequest = 30,
                    Padding = 2,
                    ClassId = "authButton",
                    Text = "Назад",
                    CornerRadius = 31,
                    BackgroundColor = Color.FromHex("#88B1DE")
                };
                backToLoginBtn.Clicked += BackToLoginBtn_Clicked;
                Button registerBtn = new Button()
                {
                    HeightRequest = 30,
                    Padding = 2,
                    ClassId = "authButton",
                    Text = "Зареєструватися",
                    CornerRadius = 31,
                    BackgroundColor = Color.FromHex("#88B1DE")
                };
                registerBtn.Clicked += RegisterBtn_Clicked;
                StackLayout navigationBtns = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = { backToLoginBtn, registerBtn },
                    HorizontalOptions = LayoutOptions.CenterAndExpand
                };
                StackLayout studendOrTeacher = new StackLayout()
                {
                    Orientation = StackOrientation.Vertical,
                    Children = {nameEntry, phone, password, controlPass, codeWord, agreementStack, navigationBtns}
                };
                regLayout.Children.Add(studendOrTeacher);
            } else
            {
                regLayout.Children.RemoveAt(3);
                Entry nameEntry = new Entry()
                {
                    Placeholder = "Прізвище ім'я"
                };
                nameEntry.TextChanged += NameEntry_TextChanged;
                Label groupLabel = new Label()
                {
                    Text = "Група"
                };
                Picker groupPick = new Picker()
                {
                    Title = "Група"
                };
                groupPick.SelectedIndexChanged += GroupPick_SelectedIndexChanged;
                groupPick.Items.Add("КІ-181");
                groupPick.Items.Add("КІ-182");
                StackLayout groupStack = new StackLayout()
                {
                    Children = { groupLabel, groupPick },
                    Orientation = StackOrientation.Horizontal
                };
                Entry phone = new Entry()
                {
                    Placeholder = "Номер телефону +380",

                    Keyboard = Keyboard.Telephone
                };
                phone.TextChanged += Phone_TextChanged;
                phone.Behaviors.Add(new MaskedBehavior() { Mask = "+38(XXX)-XX-XX-XXX" });
                Entry password = new Entry()
                {
                    Placeholder = "Пароль",
                    IsPassword = true
                };
                password.TextChanged += Password_TextChanged;
                Entry controlPass = new Entry()
                {
                    Placeholder = "Підтвердіть пароль",
                    IsPassword = true
                };
                controlPass.TextChanged += ControlPass_TextChanged;
                Label agreement = new Label()
                {
                    Text = "Я погоджуюсь на обробку персональних даних"
                };
                CheckBox agreementCheck = new CheckBox()
                {
                    IsChecked = false
                };
                agreementCheck.CheckedChanged += AgreementCheck_CheckedChanged;
                StackLayout agreementStack = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = { agreement, agreementCheck }
                };
                Button backToLoginBtn = new Button()
                {
                    HeightRequest = 30,
                    Padding = 2,
                    ClassId = "authButton",
                    Text = "Назад",
                    CornerRadius = 31,
                    BackgroundColor = Color.FromHex("#88B1DE")
                    
                };
                backToLoginBtn.Clicked += BackToLoginBtn_Clicked;
                Button registerBtn = new Button()
                {
                    HeightRequest = 30,
                    Padding = 2,
                    ClassId = "authButton",
                    Text = "Зареєструватися",
                    CornerRadius = 31,
                    BackgroundColor = Color.FromHex("#88B1DE")
                };
                registerBtn.Clicked += RegisterBtn_Clicked;
                StackLayout navigationBtns = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = { backToLoginBtn, registerBtn },
                    HorizontalOptions = LayoutOptions.CenterAndExpand
                };
                StackLayout studendOrTeacher = new StackLayout()
                {
                    Orientation = StackOrientation.Vertical,
                    Children = { nameEntry,  groupStack, phone, password, controlPass, agreementStack, navigationBtns }
                };
                regLayout.Children.Add(studendOrTeacher);
            }
        }

        private void CodeWord_TextChanged(object sender, TextChangedEventArgs e)
        {
            thisTeacher.tCodeWord = e.NewTextValue;
        }

        private void BackToLoginBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void ControlPass_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (regSwitch.IsToggled)
            {
                thisTeacher.tPassControl = e.NewTextValue;
            }
            else
            {
                thisStudent.stuPassControl = e.NewTextValue;
            }
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (regSwitch.IsToggled)
            {
                thisTeacher.tPass = e.NewTextValue;
            }
            else
            {
                thisStudent.stuPass = e.NewTextValue;
            }
        }

        private void Phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (regSwitch.IsToggled)
            {
                thisTeacher.tPhone = e.NewTextValue;
            }
            else
            {
                thisStudent.stuPhone = e.NewTextValue;
            }
        }

        private void GroupPick_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            if(picker.SelectedIndex == 0)
            {
                thisStudent.stuGroup = "КІ-181";
            } else
            {
                thisStudent.stuGroup = "КІ-182";
            }
        }

        private void NameEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (regSwitch.IsToggled)
            {
                thisTeacher.tName = e.NewTextValue;
            }
            else
            {
                thisStudent.stuName = e.NewTextValue;
            }
        }

        private async void RegisterBtn_Clicked(object sender, EventArgs e)
        {
            
                if (regSwitch.IsToggled && (thisTeacher.tPass) == (thisTeacher.tPassControl) && personAgreement == true)
                {
                try
                {
                    WebRequest request = WebRequest.Create("https://projectobd.000webhostapp.com/functions/saveUserAPI.php");
                    request.Method = "POST"; // для отправки используется метод Post
                                             // данные для отправки
                    string data = "name=" + thisTeacher.tName + "&phone=" + thisTeacher.tPhone + "&password=" + thisTeacher.tPass + "&isTeacher=1&groupCode=none";
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
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            responseStr.Text = reader.ReadToEnd();
                            if (responseStr.Text == "Success!")
                            {
                                Navigation.PopModalAsync();
                            }
                        }
                    }
                    response.Close();
                }
                catch (Exception studentExcept)
                {

                }
                }
                else if (!regSwitch.IsToggled && (thisStudent.stuPass == thisStudent.stuPassControl) && personAgreement == true)
                {
                try
                {
                    WebRequest request = WebRequest.Create("https://projectobd.000webhostapp.com/functions/saveUserAPI.php");
                    request.Method = "POST"; // для отправки используется метод Post
                                             // данные для отправки
                    string data = "name=" + thisStudent.stuName + "&phone=" + thisStudent.stuPhone + "&password=" + thisStudent.stuPass + "&isTeacher=0&groupCode=" + thisStudent.stuGroup;
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
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            responseStr.Text = reader.ReadToEnd();
                            if (responseStr.Text == "Success!")
                            {
                                Navigation.PopModalAsync();
                            }
                        }
                    }
                    response.Close();
                }
                catch (Exception regTeacher)
                {
                    
                }
                }
            

        }
    }
}
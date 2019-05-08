using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;


namespace PortifolioWeb.Controllers
{
    public class PrincipalController : Controller
    {
        /*


        private string currentAddress = System.Configuration.ConfigurationManager.AppSettings["Address"];
        private string topic = System.Configuration.ConfigurationManager.AppSettings["Subject"];
        private string msg = System.Configuration.ConfigurationManager.AppSettings["Mensage"];
        private string iso = System.Configuration.ConfigurationManager.AppSettings["CharSet"];
        private string key = System.Configuration.ConfigurationManager.AppSettings["Psw"];
        private string server = System.Configuration.ConfigurationManager.AppSettings["Svr"];
        private string prt = System.Configuration.ConfigurationManager.AppSettings["Prt"];
        private string monitor = System.Configuration.ConfigurationManager.AppSettings["AddressMonitor"];

            */
/*
        private string currentAddress = "fernando.avargas.fv@gmail.com";
        private string topic = "Portifólio F.A.V - Contato";
       // private string msg = "Pararéns Fernando...Estão acessando o seu portifólio.";
        private string iso = "ISO-8859-1";
        private string key = "!nter0121BRRJ";
        private string server = "smtp.gmail.com";
        private string prt = "587";
        private string monitor = "fernan.assis@uol.com.br";

    */

        private static string currentAddress = "ti@fernandodeassis.com";
        private static string topic = "Portifólio F.A.V - Contato";
        // private string msg = "Pararéns Fernando...Estão acessando o seu portifólio.";
        private static string iso = "ISO-8859-1";
        private static string key = "!nter121BR";
        private static string server = "webmail.fernandodeassis.com";
        private static string prt = "587";
        private static string toAddress = "fernan.assis@uol.com.br";
        private static string monitor = "hildasilvargas@gmail.com";


        // private string conteudo = System.IO.File.ReadAllText("C:\\Users\\Fernando\\Documents\\Visual Studio 2015\\Projects\\PortifolioFernando\\PortifolioWeb\\Views\\Disparador\\TemplateContatoTeste.html");
        //private string conteudo = System.IO.File.ReadAllText("C:\\Users\\Fernando\\Documents\\Visual Studio 2015\\Projects\\PortifolioFernando\\PortifolioWeb\\Views\\Disparador\\TemplateContato.html");

        private string conteudo = "<div style=\"background: #588EBC;\"> <br><br> <div style=\"width: 100%;\"><div  style=\"font-family: verdana, arial, serif;font-size:20px;\"><img style=\"width:5%;height:5%;margin:5px; margin-left:20px;border-radius: 50%;-webkit-border-radius: 50%;-moz-border-radius: 50%;-ms-border-radius: 50%;-o-border-radius: 50%;\" src=\"http://www.fernandodeassis.com/Content/img-cst/IconeMenor.png \"/> - CONTATO</div><div style=\"background:#FFD933;text-align:center; margin: 0 auto;\"><img style =\"width:35%;height:35%;\" src=\"http://www.infrastructuredeals.com/wp-content/uploads/2015/04/call-center-agent.jpg \"/></div><div style=\"font-family:arial,verdana,tahoma; font-size:18px;\"><hr border = 2px;><div style=\"text-align:center;\"> [Nome] <br> [Email] <br> [Assunto]<br></div><hr border = 2px;><div style=\"font-size:15px;width:96%; margin: 2% ;height: 4em;background:#F8F8F8;\">[Mensagem]</div></div></div><table id = \"button\" align=\"center\" width=\"100\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" style=\"border-collapse: collapse;\"><tbody><tr><td valign = \"middle\" bgcolor=\"#7397C3\" align=\"center\" height=\"25\" style=\"border-collapse: collapse;\" mc:edit=\"shop_now\"><a style = \"color: #ffffff !important;text-decoration: none;outline: none; font-size:12px;\" href=\"http://www.fernandodeassis.com\"><font color = \"#FFFFFF\" face=\"Arial, Helvetica, sans-serif\"><singleline label = 'Shop Now' > Visitar Portifólio</singleline></font></a></td></tr></tbody></table><div><hr/><footer><p>&copy; 2017 - Portifólio F.A.V - Todos os direitos reservados</p></footer></div>";

        //private string Caminho = "http://www.360wango.com/1/wp-content/uploads/2014/09/Best-WordPress-Portfolio-Themes1.2-230x130.jpg";


        public ActionResult Inicio()
        {

            return View();

        }

        [HttpPost]

       

        public ActionResult Inicio(string Nome, string Email, string Assunto, string Mensagem)
        {

            conteudo = conteudo.Replace("[Nome]",Nome);
            conteudo = conteudo.Replace("[Email]", Email);
            conteudo = conteudo.Replace("[Assunto]", Assunto);
            conteudo = conteudo.Replace("[Mensagem]", Mensagem);       
          //  conteudo = conteudo.Replace("[Caminho]", Caminho);

    


            MailMessage email = new MailMessage();

            email.From = new MailAddress(currentAddress);
            email.To.Add(toAddress);
            email.Subject = topic;
            email.CC.Add(monitor);
            email.Body = conteudo;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;
            email.SubjectEncoding = System.Text.Encoding.GetEncoding(iso);
            email.BodyEncoding = System.Text.Encoding.GetEncoding(iso);

            System.Net.Mail.SmtpClient Smtp = new System.Net.Mail.SmtpClient();

            //Alocamos o endereço do host para enviar os e-mails  
            Smtp.Credentials = new System.Net.NetworkCredential(currentAddress, key);
            Smtp.Host = server;
            Smtp.Port = Convert.ToInt32(prt);
            Smtp.EnableSsl = false;

            try
            {
                Smtp.Send(email);

                return View();

            }
            catch (Exception ex)
            {
                ViewBag.Error = "Erro ao tentar carregar a página... Contacte o administrador: ti@fernandodeassis.com. Obrigado." + ex.Message;

            }

            return View();

        }

 
        public ActionResult Lgn()
        {
            return View();
        }

    }
}

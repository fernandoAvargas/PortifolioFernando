using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace PortifolioWeb.Controllers
{
    public class ConsultoriaController : Controller
    {
        /*
        
        private string currentAddress = System.Configuration.ConfigurationManager.AppSettings["CorpAddress"];
        private string topic = System.Configuration.ConfigurationManager.AppSettings["CorpSubject"];
        private string msg = System.Configuration.ConfigurationManager.AppSettings["CorpMensage"];
        private string iso = System.Configuration.ConfigurationManager.AppSettings["CorpCharSet"];
        private string key = System.Configuration.ConfigurationManager.AppSettings["CorpPsw"];
        private string server = System.Configuration.ConfigurationManager.AppSettings["CorpSvr"];
        private string prt = System.Configuration.ConfigurationManager.AppSettings["CorpPrt"];
        private string monitor = System.Configuration.ConfigurationManager.AppSettings["AddressMonitor"];

    */

        private static string currentAddress = "ti@fernandodeassis.com";
        private static string topic = "TI - Consultoria - Contato";
        private static string iso = "ISO-8859-1";
        private static string key = "!nter121BR";
        private static string server = "webmail.fernandodeassis.com"; 
        private static string prt = "587";
        private static string toAddress = "fernan.assis@uol.com.br";
        private static string monitor = "hildasilvargas@gmail.com";

        private string conteudo = "<div style=\"background: #588EBC;\"> <br><br> <div style=\"width: 100%;\"><div  style=\"font-family: verdana, arial, serif;font-size:20px;\"><img style=\"width:5%;height:5%;margin:5px; margin-left:20px;border-radius: 50%;-webkit-border-radius: 50%;-moz-border-radius: 50%;-ms-border-radius: 50%;-o-border-radius: 50%;\" src=\"http://www.fernandodeassis.com/Content/img-cst/IconeMenor.png \"/> - CONTATO</div><div style=\"background:#FFD933;text-align:center; margin: 0 auto;\"><img style =\"width:35%;height:35%;\" src=\"http://www.infrastructuredeals.com/wp-content/uploads/2015/04/call-center-agent.jpg \"/></div><div style=\"font-family:arial,verdana,tahoma; font-size:18px;\"><hr border = 2px;><div style=\"text-align:center;\"> [Nome] <br> [Email] <br> [Assunto]<br></div><hr border = 2px;><div style=\"font-size:15px;width:96%; margin: 2% ;height: 4em;background:#F8F8F8;\">[Mensagem]</div></div></div><table id = \"button\" align=\"center\" width=\"100\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" style=\"border-collapse: collapse;\"><tbody><tr><td valign = \"middle\" bgcolor=\"#7397C3\" align=\"center\" height=\"25\" style=\"border-collapse: collapse;\" mc:edit=\"shop_now\"><a style = \"color: #ffffff !important;text-decoration: none;outline: none; font-size:12px;\" href=\"http://www.fernandodeassis.com/consultoria \"><font color = \"#FFFFFF\" face=\"Arial, Helvetica, sans-serif\"><singleline label = 'Shop Now' > Nosso Site</singleline></font></a></td></tr></tbody></table><div><hr/><footer><p>&copy; 2017 - Portifólio F.A.V - Todos os direitos reservados</p></footer></div>";
        //private string conteudo = System.IO.File.ReadAllText("C:\\Users\\Fernando\\Documents\\Visual Studio 2015\\Projects\\PortifolioFernando\\PortifolioWeb\\Views\\Disparador\\TemplateContato.html");
        private static string caminho = "http://www.fernandodeassis.com/Content/img-cst/IconeMenor.png";

        // GET: Consultoria
        public ActionResult Inicio()
        {

            return View();


        }


        public ActionResult Contato()
        {

            return View();


        }


        [HttpPost]

        public ActionResult Contato(string Nome, string Email, string Assunto, string Mensagem)
        {


            conteudo = conteudo.Replace("[Nome]", Nome);
            conteudo = conteudo.Replace("[Email]", Email);
            conteudo = conteudo.Replace("[Assunto]", Assunto);
            conteudo = conteudo.Replace("[Mensagem]", Mensagem);
            conteudo = conteudo.Replace("[Caminho]", caminho);



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














        public ActionResult Sobre()
        {

            return View();

        }


    }
}
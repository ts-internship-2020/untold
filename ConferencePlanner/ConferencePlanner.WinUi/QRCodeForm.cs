using QRCoder;
using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi
{
    public partial class QRCodeForm : Form
    {
        public QRCodeForm()
        {
            InitializeComponent();
        }

        private void QRCodeForm_Load(object sender, EventArgs e)
        {
            string qrCode = Program.qrCode;
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(qrCode, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            pictureBox1.Image = code.GetGraphic(11);
            pictureBox1.Image.Save("../../../Resources/qrCode.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
                using (MailMessage mail = new MailMessage())
                {
                    mail.Attachments.Add(new Attachment("../../../Resources/qrCode.jpeg"));
                    mail.From = new MailAddress("testare.aplicatie.ts@gmail.com");
                    mail.To.Add(Program.EnteredEmailAddress);
                    mail.Subject = "QR Code for conference authentification";
                    mail.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("testare.aplicatie.ts@gmail.com", "testing1.");
                        smtp.EnableSsl = true;
                    try
                    {
                        smtp.Send(mail);
                    }
                    catch (Exception ex)
                    {

                    }
                    //catch (System.Net.Email)
                    }
                }
                Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

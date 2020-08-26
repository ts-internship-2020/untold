using ConferencePlanner.Repository.Ado.Repository;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image image = pictureBox1.Image;
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("testare.aplicatie.ts@gmail.com");
                mail.To.Add(Program.EnteredEmailAddress);
                mail.Subject = "QR Code autentificare conferinta";
                mail.Body = image.ToString();
                mail.IsBodyHtml = false;
               //desenare body html
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("testare.aplicatie.ts@gmail.com", "testing1.");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

    }
}

using System;
using System.Windows.Forms;

using System;
using System.Net;
using System.Net.Mail;

namespace email_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Set up the sender's email address and password
            string senderEmail = "g.allcock@priestley.ac.uk";
            string senderPassword = "pltl kpfz qztf hsnr";

            // Set up the recipient's email address
            //string recipientEmail = "gallcockmail@googlemail.com";
            string recipientEmail = txt_email.Text;

            // Create a new MailMessage
            MailMessage mail = new MailMessage(senderEmail, recipientEmail);

            // Set the subject and body of the email
            mail.Subject = "Test Email sent out";
            mail.Body = "This is a test email sent from C#.";

            // Set up the SMTP client
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587; // Use 587 for Gmail
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = true;

            try
            {
                // Send the email
                smtpClient.Send(mail);
                lbl_status.Text = "Email sent successfully!";
                //Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }
    }
}

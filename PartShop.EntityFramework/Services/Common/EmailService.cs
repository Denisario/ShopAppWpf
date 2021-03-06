﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using PartShop.Domain.Model;
using PartShop.Domain.Services;

namespace PartShop.EntityFramework.Services.Common
{
    public class EmailService : IEmailService
    {
        private readonly IAccountService _accountService;
        private MailAddress mailFrom;
        private SmtpClient smtpClient;

        public EmailService(IAccountService accountService)
        {
            _accountService = accountService;
            mailFrom = new MailAddress("partshopcourse@gmail.com");
            smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential("partshopcourse@gmail.com", "Coursework");
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        }

        public async Task SendOrderEmail(Order order, string header, string text)
        {

            Account account = await _accountService.Get(order.AccountId);

            MailAddress mailTo = new MailAddress(account.Email);
            MailMessage m = new MailMessage(mailFrom, mailTo) {Subject = header, Body = text};
            await smtpClient.SendMailAsync(m);
        }

        public async Task SendPartEmail(Account account, string header, string text)
        {
            MailAddress mailTo = new MailAddress(account.Email);
            MailMessage m = new MailMessage(mailFrom, mailTo) {Subject = header, Body = text};
            await smtpClient.SendMailAsync(m);
        }
    }
}
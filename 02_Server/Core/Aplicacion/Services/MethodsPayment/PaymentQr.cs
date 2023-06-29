﻿using Aplicacion.Interfaces.Repositories;
using Dominio.Common.Function;
using Dominio.Entities.Qr;
using ServiceUniQr;
using System;
using static Dominio.Entities.Qr.ResponseXml;

namespace Aplicacion.Services.MethodsPayment
{
    public class PaymentQr : IPaymentQr
    {
        public string GenerateQr(string content)
        {
            try
            {
                Manager manager = new();
                
                RequestHeader requestHeader = new()
                {
                    Service = "SEDEM_QR_001",
                    User = "SEDEM_QR",
                    Password = "CysRcsYHlmYFnbp6EmIklA=="
                };
                Item item = new()
                {
                    ItemDescription = "Tramite",
                    ItemValue = "564122"
                };
                Items items = new()
                {
                    Item= item
                };
                RequestGetQr requestGetQr = new()
                {
                    Account = "10000026017645",
                    Amount = "6000",
                    Currency = "BOB",
                    Reference = "Subsidio Prenatal-Banco de Credito",
                    Valid = "S",
                    FormatQr = "1",
                    Items = items
                };
                RequestXml requestXml = new()
                {
                    requestGetQr = requestGetQr,
                    requestHeader = requestHeader
                };
                Function function = new();
                string xmlRequest = function.SerializeToString(requestXml);
                string xmlSigned = manager.KeyXml(xmlRequest);
                string response = manager.Conection(xmlSigned);
                Signature signatureMethod = function.ConvertXmlToObject<Signature>(response);
                return response;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

}

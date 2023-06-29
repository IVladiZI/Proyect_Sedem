using Aplicacion.DTOs.Cliente;
using Aplicacion.DTOs.Qr;
using Infraestructura.Abstract;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Threading.Tasks;

namespace Server.Pages.Pagos
{
    public partial class PagoDetalle
    {
        MudForm moudFormQrPay;
        public string SubmitedUrl { get; set; }
        public string QRCodeText { get; set; }

        public QrClienteDto _qrClienteDto { get; set; }
        public FcClientePagoDto _fcClientePagoDto = new FcClientePagoDto();
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public FcClienteDto fcClienteDto { get; set; }
        protected override void OnInitialized()
        {
            _fcClientePagoDto.Detalle = fcClienteDto.Cliente;
            _fcClientePagoDto.Monto = (Decimal)fcClienteDto.Cantidad * 2250;
            _fcClientePagoDto.IdfcCliente = fcClienteDto.IdfcCliente;
            _fcClientePagoDto.FechaPago = DateTime.Now;
            _fcClientePagoDto.Estado = "Proceso";
        }
        private async Task ClientePagoNuevo()
        {
            await Save();

        }
        private async Task QrPayment()
        {
            try
            {
                _Loading.Show();
                var vrespost = await _Qr.PostAsync<string>("QrClienet", _qrClienteDto);
                QRCodeText = vrespost.ToString();
                _Loading.Hide();
                _MessageShow(vrespost.Message, vrespost.State);

                if (vrespost.State != State.Success)
                {
                    vrespost.Errors.ForEach(x =>
                    {
                        _MessageShow(x, State.Warning);
                    });
                    MudDialog.Close(DialogResult.Ok(true));
                    return;
                }
                else
                {
                    _MessageShow("Se registro Correctamente..", State.Success);
                }
            }
            catch (Exception e)
            {
                _Loading.Hide();
                _MessageShow(e.Message, State.Error);
            }
        }
        protected async Task Save()
        {
            try
            {
                _Loading.Show();
                var vrespost = await _Rest.PostAsync<int?>("FcClientePago", new { fcClientePagoDto = _fcClientePagoDto });
                _Loading.Hide();
                _MessageShow(vrespost.Message, vrespost.State);

                if (vrespost.State != State.Success)
                {
                    vrespost.Errors.ForEach(x =>
                    {
                        _MessageShow(x, State.Warning);
                    });
                    MudDialog.Close(DialogResult.Ok(true));
                    return;
                }
                else
                {
                    _MessageShow("Se registro Correctamente..", State.Success);
                }
            }
            catch (Exception e)
            {
                _Loading.Hide();
                _MessageShow(e.Message, State.Error);
            }
        }
        void Cancel() => MudDialog.Cancel();
    }
}

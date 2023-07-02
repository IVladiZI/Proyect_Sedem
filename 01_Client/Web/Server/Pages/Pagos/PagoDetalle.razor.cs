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

        public FcQrClienteDto fcQrClienteDto = new();
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public FcClienteDto FcClienteDto { get; set; }
        protected override void OnInitialized()
        {
            fcQrClienteDto.IdfcCliente = FcClienteDto.IdfcCliente;
            fcQrClienteDto.QrGlosa = FcClienteDto.Cliente;
            fcQrClienteDto.QrMonto = (Decimal)FcClienteDto.Cantidad * 2250;
        }
        private async Task QrPayment()
        {
            try
            {
                _Loading.Show();
                var vrespost = await _QrRest.PostAsync<string>("FcQrCliente", new { fcQrClienteDto = fcQrClienteDto });
                _Loading.Hide();
                
                
                if (vrespost.State != State.Success)
                {
                    _MessageShow(vrespost.Message, State.Warning);
                    MudDialog.Close(DialogResult.Ok(true));
                    return;
                }
                else
                {
                    QRCodeText = vrespost.Data;
                    StateHasChanged();
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

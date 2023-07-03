using Aplicacion.DTOs.Cliente;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using State = Infraestructura.Abstract.State;
namespace Server.Pages.Pagos
{
    public partial class PagoReporte
    {
        private static List<FcClientePagoDto> fcClientePagos { get; set; }
        //public FcClientePagoDto FcClientePagoDto = new();
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter] public int IdfcCliente { get; set; }

        private bool dense = true;
        private bool hover = true;
        private bool striped = true;
        private bool bordered = true;
        protected override async void OnInitialized()
        {
            await GetPagoReporte();
        }
        protected async Task GetPagoReporte()
        {
            try
            {
                _Loading.Show();
                var _result = await _Rest.GetAsync<List<FcClientePagoDto>>("FcClientePago");
                _Loading.Hide();
                if (_result.State != State.Success)
                {
                    _DialogShow(_result.Message, _result.State);
                }
                fcClientePagos = _result.Data;
                StateHasChanged();
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        }
        void Submit() => MudDialog.Close(DialogResult.Ok(true));
        void Cancel() => MudDialog.Cancel();
    }
}

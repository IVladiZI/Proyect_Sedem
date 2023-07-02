﻿using Aplicacion.DTOs.Cliente;
using MudBlazor;
using Server.Pages.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using State = Infraestructura.Abstract.State;

namespace Server.Pages.Cliente
{
    public partial class Cliente
    {
        private static List<FcClienteDto> cliente { get; set; }
        public FcClienteDto _ClienteNuevo = new ();
        
        private DialogParameters dialogParameters=new();

        private bool dense = true;
        private bool hover = true;
        private bool striped = true;
        private bool bordered = true;
        
        protected override async void OnInitialized()
        {
            await GetCliente();
        }

        protected async Task GetCliente()
        {
            try
            {
                _Loading.Show();
                var _result = await _Rest.GetAsync<List<FcClienteDto>>("FcCliente");
                _Loading.Hide();
                if (_result.State != State.Success)
                {
                    _DialogShow(_result.Message, _result.State);
                }
                cliente = _result.Data;
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        }

        //////EDITAR 

        protected void ShowBtnEditSave(int idpruebas)
        {
            var vpruebas = cliente.First(f => f.IdfcCliente == idpruebas);
            vpruebas.VerDetalle = !vpruebas.VerDetalle;
        }


        protected async void ShowBtnEditSave(FcClienteDto dato)
        {
            await editarpruebas(dato);


        }
        protected async Task editarpruebas(FcClienteDto dato)
        {
            try
            {
                _Loading.Show();
                var _update = await _Rest.PutAsync<int>("FcCliente", dato, dato.IdfcCliente);
                if (_update.State == State.Success)
                {
                    _MessageShow(_update.Message, _update.State);
                    dato.IdfcCliente = _update.Data;
                    dato.VerDetalle = !dato.VerDetalle;
                    StateHasChanged();
                }
                else
                {
                    _MessageShow(_update.Message, _update.State);
                }
            }
            catch (Exception e)
            {
                _DialogShow(e.Message, State.Error);
            }
            finally
            {
                _Loading.Hide();
            }
        }

        protected async void ShowBtnEditSaveCancel(int IdfcCliente, FcClienteDto dato)
        {
            var vafiliacion = cliente.First(f => f.IdfcCliente == IdfcCliente);
            vafiliacion.VerDetalle = !vafiliacion.VerDetalle;
        }

        private async Task ClienteNuevo()
        {
            await Save();

        }
        protected async Task Save()
        {
            try
            {
                _Loading.Show();
                var vrespost = await _Rest.PostAsync<int?>("FcCliente", new { fcClienteDto = _ClienteNuevo });
                _Loading.Hide();
                _MessageShow(vrespost.Message, vrespost.State);

                if (vrespost.State != State.Success)
                {
                    vrespost.Errors.ForEach (x =>
                    {
                        _MessageShow(x, State.Warning);
                    }) ;
                    StateHasChanged();
                    return;
                }
                else
                {
                    _MessageShow("Se registro Correctamente..", State.Success);
                    await GetCliente();
                }



            }
            catch (Exception e)
            {
                _Loading.Hide();
                _MessageShow(e.Message, State.Error);
            }
        }

        public async Task Eliminar(int idpruebas)
        {
            await _MessageConfirm("esta seguro de eliminar el registro...?", async () =>
            {
                var vrespost = await _Rest.DeleteAsync<int>("FcCliente", (int)idpruebas);
                if (!vrespost.Succeeded)
                {
                    _MessageShow(vrespost.Message, State.Error);
                }
                else
                {
                    //await getlistestractouninet();
                    await GetCliente();
                    StateHasChanged();
                }
            });
        }
        public void AbrirMetodoPago(FcClienteDto fcClienteDto)
        {
            try
            {
                dialogParameters.Add("fcClienteDto",fcClienteDto);
                var options = new DialogOptions() {
                    MaxWidth = MaxWidth.Medium,
                    FullWidth = true,
                    Position = DialogPosition.TopCenter
                };
                DialogService.Show<PagoDetalle>("Detalle Pago", dialogParameters, options);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public void AbrirReportePago(int IdfcCliente)
        {
            try
            {
                dialogParameters.Add("IdfcCliente", IdfcCliente);
                var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };
                DialogService.Show<PagoReporte>("Reporte Pagos", dialogParameters, options);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }



}

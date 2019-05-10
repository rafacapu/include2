using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

using ProjectCEP.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectCEP.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        #region Global

        INavigationService _navigationService; 

        #endregion

        #region Binding
        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        #endregion

        #region Command 
        public DelegateCommand ClickNavigationCommand { get; set; }

        #endregion
        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "MaingPage";

            ClickNavigationCommand = new DelegateCommand(ExecuteClickNavigationCommand);
        }
        
        private void ExecuteClickNavitagationCommand()
        {
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {3} - {0} - {1},{2}", end.bairro, end.localidade, end.uf, end.logradouro);
                    }

                   

                }
                catch (Exception e)
                {
                    DisplayAlert("ERRO ", e.Message, "OK");
                }
            }
        }

        private bool isValidCEP(string cep)
        {
            bool valido = true;

            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP inválido!.", "OK");
                valido = false;
            }

            int NovoCEP = 0;

            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("ERRO", "CEP inválido! ", "OK");
                valido = false;
            }

            return valido;
        }


    }
}

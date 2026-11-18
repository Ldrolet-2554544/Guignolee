using Guignolee.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Guignolee.ViewModels
{
    public class DonViewModel : ValidableViewModel
    {
        private readonly Don _don;

        public DonViewModel(Don don)
        {
            _don = don;
            _errors.Add(nameof(Donateur), new ObservableCollection<ValidationResult>());
            Validate(Donateur, nameof(Donateur));
            _errors.Add(nameof(Contenu), new ObservableCollection<ValidationResult>());
            Validate(Contenu, nameof(Contenu));
            _errors.Add(nameof(Quantite), new ObservableCollection<ValidationResult>());
            Validate(Quantite, nameof(Quantite));
        }

        public int Id => _don.Id;

        [Required(ErrorMessage = "Le donateur est requis")]
        [MinLength(2, ErrorMessage = "Le nom du donateur est trop petit")]
        [MaxLength(50, ErrorMessage = "Le nom du donateur doit comprendre moins de 50 caractères.")]
        [RegularExpression(@"^[\w\s]+$", ErrorMessage = "Le contenu n'est pas valide")]
        public string Donateur
        {
            get { return _don.Donateur; }
            set
            {
                if (_don.Donateur != value)
                {
                    _don.Donateur = value;
                    RaisePropertyChanged();
                }
            }
        }

        [Required(ErrorMessage = "Le contenu est requis")]
        [MinLength(2, ErrorMessage = "Le contenu est trop petit")]
        [MaxLength(50, ErrorMessage = "Le contenu comprendre moins de 50 caractères.")]
        [RegularExpression(@"^[\w\s]+$", ErrorMessage = "Le contenu n'est pas valide")]
        public string Contenu
        {
            get { return _don.Contenu; }
            set
            {
                if (_don.Contenu != value )
                {
                    _don.Contenu = value;
                    RaisePropertyChanged();
                }
            }
        }
        [Required(ErrorMessage = "La quantité est requise")]
        [Range(1, 100, ErrorMessage ="La quantité dois être entre 1 et 100 articles")]
        public int Quantite
        {
            get { return _don.Quantite; }
            set
            {
                if (Quantite != value)
                {
                    _don.Quantite = value;
                    RaisePropertyChanged();

                }
            }
        }

        public bool EstPerissable
        {
            get { return _don.EstPerissable; }
            set
            {
                if (_don.EstPerissable != value)
                {
                    _don.EstPerissable = value;
                }
            }
        }

        public bool EstRemis
        {
            get { return _don.EstRemis; }
            set
            {
                if (_don.EstRemis != value)
                {
                    _don.EstRemis = value;
                }
            }
        }

        public DateTime DateReception => _don.DateReception;

        public string Details
        {
            get
            {
                return $"{_don.Quantite} article(s) - {_don.Donateur} - reçu le {_don.DateReception:dd-MM-yyyy}";
            }
        }
    }
}

using System;
using System.Globalization;

namespace P001_V2
{
    public class Salarie
    {
        #region Champs privés

        private static int _nombreInstances;
        private string _matricule;
        private string _nom = string.Empty;
        private string _prenom = string.Empty;
        private decimal _salaireBrut;
        private decimal _tauxCS;
        private DateTime _dateNaissance;
        #endregion

        #region Propriétés
        /// <summary>
        /// Nombres d'instances
        /// </summary>
        public static int NombreInstances
        {
            get
            {
                return _nombreInstances;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Matricule
        {
            get { return (this._matricule); }
            set
            {
                if (!IsMatriculeValide(value)) throw new ApplicationException("Matricule invalide");
                _matricule = value;

            }
        }
        /// <summary>
        /// Vérification du matricule
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsMatriculeValide(string value)
        {
            if (String.IsNullOrEmpty(value) || value.Length != 7)
            {
                return false;
            }
            for (int i = 0; i < value.Length; i++)
            {
                if (((i >= 0 && i < 2) || (i > 4)) && !Char.IsDigit(value[i])
                    || ((i > 1 && i < 5) && !Char.IsLetter(value[i])))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Nom du salarié
        /// Longueur comprise entre 3 et 30 caractères. Ni caractères spéciaux ni chiffres 
        /// </summary>
        public string Nom
        {
            get { return (this._nom); }
            set
            {
                if (!IsNomValide(value)) throw new ApplicationException(string.Format(CultureInfo.CurrentCulture, "Le nom {0} n'est pas valide.", value)); ;
                this._nom = string.Format(CultureInfo.CurrentCulture, "{0}{1}", value.Trim().Substring(0, 1).ToUpper(CultureInfo.CurrentCulture), value.Trim().Substring(1, value.Trim().Length - 1).ToLower(CultureInfo.CurrentCulture));
            }
        }



        /// <summary>
        /// Prenom 
        /// </summary>
        public string Prenom
        {
            get { return (this._prenom); }
            set
            {
                if (!IsPrenomValide(value)) throw new ApplicationException(string.Format("Le prénom {0} n'est pas valide.", value)); ;
                _prenom = string.Format(CultureInfo.CurrentCulture, "{0}{1}", value.Trim().Substring(0, 1).ToUpper(CultureInfo.CurrentCulture), value.Trim().Substring(1, value.Trim().Length - 1).ToLower(CultureInfo.CurrentCulture));
            }
        }



        /// <summary>
        /// Salaire brut
        /// </summary>
        public decimal SalaireBrut
        {
            get { return (this._salaireBrut); }
            set
            {
                _salaireBrut = value;

            }

        }
        /// <summary>
        /// Taux de charges sociales affecté
        /// Ne peut excéder 0.6
        /// </summary>
        public decimal TauxCS
        {
            get { return (_tauxCS); }
            set
            {
                if (!IsTauxValide(value))
                {
                    throw new Exception(string.Format(CultureInfo.CurrentCulture, "Le taux {0} n'est pas acceptable.", value));
                }
                _tauxCS = value;

            }
        }
        /// <summary>
        /// Date de naissance
        /// Ne peut être antérieure au 1er janvier 1900 et postérieure à J -15 ans
        /// </summary>
        public DateTime DateNaissance
        {
            get { return (this._dateNaissance); }
            set
            {
                if (!IsDateNaissanceValide(value))
                {
                    throw new Exception($"La Date de naissance {value:d} doit être comprise entre le 1 janvier 1900 et le " +
                        $"{DateTime.Today.AddYears(-15):d}");
                }
                _dateNaissance = value;
            }
        }

        /// <summary>
        /// Salaire touché par le salarie apres déduction des charges sociales
        /// </summary>
        public virtual decimal SalaireNet
        {
            get { return this._salaireBrut * (1 - _tauxCS); }
        }

        #endregion
        #region Méthodes de contrôle
        public static bool IsPrenomValide(string value)
        {
            if (value == null || value.Trim().Length < 3 || value.Trim().Length > 30) return false;

            foreach (char caractere in value)
            {
                if (!char.IsLetter(caractere)) return false;
            }
            return true;
        }

        public static bool IsNomValide(string value)
        {
            if (value == null || value.Trim().Length < 3 || value.Trim().Length > 30)
                return false;

            foreach (char caractere in value)
            {
                if (!char.IsLetter(caractere)) return false;
            }
            return true;
        }
        public static bool IsTauxValide(decimal value)
        {
            return (value > 0) && (value <= 0.6m);
        }
        public static bool IsDateNaissanceValide(DateTime value)
        {
            return (value.CompareTo(new DateTime(1900, 01, 01)) > 0
                && value.CompareTo(DateTime.Today.AddYears(-15)) < 0);
        }
        #endregion
        #region Constructeurs
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Salarie()
        {
            _nombreInstances++;
        }

        /// <summary>
        /// Constructeur de recopie
        /// </summary>
        /// <param name="salarie"></param>
        public Salarie(Salarie salarie)
            : this(salarie.Nom, salarie.Prenom, salarie.Matricule)
        {
            if (salarie != null)
            {

                this.SalaireBrut = salarie.SalaireBrut;
                this.TauxCS = salarie.TauxCS;
                this.DateNaissance = salarie.DateNaissance;
            }
        }
        /// <summary>
        /// Constructeur d'initialisation partielle
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="matricule"></param>
        public Salarie(string nom, string prenom, string matricule)
            : this()
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Matricule = matricule;

        }

        #endregion
        #region Destructeur
        /// <summary>
        /// Destructeur pour tests
        /// </summary>
        ~Salarie()
        {
            _nombreInstances--;

        }
        #endregion
        public override bool Equals(object obj)
        {
            Salarie sal = obj as Salarie;
            if (sal == null) return false;
            if (this._matricule == sal._matricule) return true;
            else return false;


        }
        public override int GetHashCode()
        {

            return this._matricule.GetHashCode();
        }
        public override string ToString()
        {

            return string.Format($"Matricule {_matricule}, Prenom {_prenom}, " +
                $"Nom {_nom}, Date Naissance {_dateNaissance}, Salaire Brut {_salaireBrut}, TauxCS {_tauxCS}");


        }
    } }
    
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HeritagesProjectG6.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UTILISATEUR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UTILISATEUR()
        {
            this.AYANTDROIT = new HashSet<AYANTDROIT>();
        }
    
        public int UTILISATEURID { get; set; }
        public Nullable<int> UTI_UTILISATEURID { get; set; }
        public string DESIGNATION { get; set; }
        public string EMAIL { get; set; }
        public string pwd { get; set; }

        public string TYPEUTILISATEUR { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AYANTDROIT> AYANTDROIT { get; set; }
    }
}

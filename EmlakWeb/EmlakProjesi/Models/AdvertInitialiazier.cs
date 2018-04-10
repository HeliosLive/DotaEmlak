using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace EmlakProjesi.Models
{
    // Global.ASAX içine yazıldı bu kısım.
    //EĞER MODELLERDE DEĞİŞİKLİK OLURSA DATABASE İ SİLER INITIALIAZIER KISMI FAKAT BİZ BUNU BU PROJEDE İSTEMİYORUZ. DEĞİŞİKLİK OLURSA DATABASE DE MANUEL DE EKLEMELİYİZ.
    public class AdvertInitialiazier : DropCreateDatabaseIfModelChanges<AdvertContext>
    {
        protected override void Seed(AdvertContext context)
        {
            base.Seed(context);
        }
    }
}
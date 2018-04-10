namespace EmlakProjesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adverts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MainImage = c.String(),
                        Baslik = c.String(),
                        Adres = c.String(),
                        Detaylar = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        PropertyTypeId = c.Int(nullable: false),
                        SellingTypeId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        DistrictId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        Fiyat = c.Single(nullable: false),
                        Boyut = c.Int(nullable: false),
                        Yas = c.Int(nullable: false),
                        KatSayisi = c.Int(nullable: false),
                        BuluduguKat = c.Int(nullable: false),
                        BanyoSayisi = c.Int(nullable: false),
                        BalkonSayisi = c.Int(nullable: false),
                        EsyaDurumu = c.Boolean(nullable: false),
                        HeatingId = c.Int(nullable: false),
                        AdvertTypeId = c.Int(nullable: false),
                        KullanimDurumu = c.Boolean(nullable: false),
                        Aidat = c.Single(nullable: false),
                        UserId = c.Int(nullable: false),
                        SessionString = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PropertyTypes", t => t.PropertyTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.AdvertTypes", t => t.AdvertTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .ForeignKey("dbo.Heatings", t => t.HeatingId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.SellingTypes", t => t.SellingTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.PropertyTypeId)
                .Index(t => t.SellingTypeId)
                .Index(t => t.CityId)
                .Index(t => t.DistrictId)
                .Index(t => t.RoomId)
                .Index(t => t.HeatingId)
                .Index(t => t.AdvertTypeId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PropertyTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AdvertTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AdvertId = c.Int(nullable: false),
                        Premium = c.Boolean(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CityId = c.Int(nullable: false),
                        CityName = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Heatings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SellingTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false),
                        Soyad = c.String(nullable: false),
                        EMail = c.String(nullable: false),
                        TelNo = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        RePassword = c.String(nullable: false),
                        RoleId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        DistrictId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImageId = c.String(),
                        SessionString = c.String(),
                        AdvertId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Qualifications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Side_North = c.Boolean(nullable: false),
                        Side_South = c.Boolean(nullable: false),
                        Side_West = c.Boolean(nullable: false),
                        Side_East = c.Boolean(nullable: false),
                        RoomType_TV = c.Boolean(nullable: false),
                        RoomType_Tel = c.Boolean(nullable: false),
                        RoomType_MoneyCase = c.Boolean(nullable: false),
                        RoomType_Closet = c.Boolean(nullable: false),
                        RoomType_WashingMachine = c.Boolean(nullable: false),
                        RoomType_DishWasher = c.Boolean(nullable: false),
                        RoomType_LaundryRoom = c.Boolean(nullable: false),
                        RoomType_AirConditioner = c.Boolean(nullable: false),
                        RoomType_Cellar = c.Boolean(nullable: false),
                        RoomType_Balcony = c.Boolean(nullable: false),
                        RoomType_Terrace = c.Boolean(nullable: false),
                        RoomType_Barbeque = c.Boolean(nullable: false),
                        RoomType_WhiteAppliances = c.Boolean(nullable: false),
                        RoomType_Refrigerator = c.Boolean(nullable: false),
                        RoomType_ParentBath = c.Boolean(nullable: false),
                        RoomType_Kartonpiyer = c.Boolean(nullable: false),
                        RoomType_Ankastre = c.Boolean(nullable: false),
                        RoomType_Laminant = c.Boolean(nullable: false),
                        RoomType_Panjur = c.Boolean(nullable: false),
                        RoomType_Furniture = c.Boolean(nullable: false),
                        RoomType_SteelDoor = c.Boolean(nullable: false),
                        RoomType_Thermopane = c.Boolean(nullable: false),
                        RoomType_SeramikGround = c.Boolean(nullable: false),
                        RoomType_ParkeGround = c.Boolean(nullable: false),
                        RoomType_FirePlace = c.Boolean(nullable: false),
                        BathroomType_Tub = c.Boolean(nullable: false),
                        BathroomType_Jacuzzi = c.Boolean(nullable: false),
                        BathroomType_Cabin = c.Boolean(nullable: false),
                        BathroomType_Alaturka = c.Boolean(nullable: false),
                        BathroomType_Alafranga = c.Boolean(nullable: false),
                        ViewType_Mountain = c.Boolean(nullable: false),
                        ViewType_Sea = c.Boolean(nullable: false),
                        ViewType_Bosphorus = c.Boolean(nullable: false),
                        ViewType_Forest = c.Boolean(nullable: false),
                        ViewType_City = c.Boolean(nullable: false),
                        ViewType_Historical = c.Boolean(nullable: false),
                        GroundType_ADSL = c.Boolean(nullable: false),
                        GroundType_Fiber = c.Boolean(nullable: false),
                        GroundType_Wifi = c.Boolean(nullable: false),
                        GroundType_CableTV = c.Boolean(nullable: false),
                        Environment_PreSchool = c.Boolean(nullable: false),
                        Environment_MidSchool = c.Boolean(nullable: false),
                        Environment_University = c.Boolean(nullable: false),
                        Environment_Hospital = c.Boolean(nullable: false),
                        Environment_Mosque = c.Boolean(nullable: false),
                        Environment_Avm = c.Boolean(nullable: false),
                        Environment_Municipality = c.Boolean(nullable: false),
                        Environment_Market = c.Boolean(nullable: false),
                        Environment_FunLand = c.Boolean(nullable: false),
                        Environment_Police = c.Boolean(nullable: false),
                        Environment_Park = c.Boolean(nullable: false),
                        Transport_Bus = c.Boolean(nullable: false),
                        Transport_Minibus = c.Boolean(nullable: false),
                        Transport_Subway = c.Boolean(nullable: false),
                        Transport_Tem = c.Boolean(nullable: false),
                        Transport_E5 = c.Boolean(nullable: false),
                        Transport_Metrobus = c.Boolean(nullable: false),
                        Transport_Teleferik = c.Boolean(nullable: false),
                        Transport_Tramvay = c.Boolean(nullable: false),
                        Transport_Pier = c.Boolean(nullable: false),
                        Transport_Airport = c.Boolean(nullable: false),
                        HousingType_Arakat = c.Boolean(nullable: false),
                        HousingType_Bahceli = c.Boolean(nullable: false),
                        HousingType_Bahcekati = c.Boolean(nullable: false),
                        HousingType_TersDublex = c.Boolean(nullable: false),
                        HousingType_Arakatdublex = c.Boolean(nullable: false),
                        HousingType_Enustkat = c.Boolean(nullable: false),
                        HousingType_Triplex = c.Boolean(nullable: false),
                        HousingType_Bahcedublex = c.Boolean(nullable: false),
                        HousingType_Catidublex = c.Boolean(nullable: false),
                        HousingType_Mustakil = c.Boolean(nullable: false),
                        SessionString = c.String(),
                        AdvertId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Adverts", t => t.AdvertId, cascadeDelete: true)
                .Index(t => t.AdvertId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Qualifications", "AdvertId", "dbo.Adverts");
            DropForeignKey("dbo.Adverts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.UserRoles");
            DropForeignKey("dbo.Adverts", "SellingTypeId", "dbo.SellingTypes");
            DropForeignKey("dbo.Adverts", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Adverts", "HeatingId", "dbo.Heatings");
            DropForeignKey("dbo.Adverts", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Adverts", "AdvertTypeId", "dbo.AdvertTypes");
            DropForeignKey("dbo.Adverts", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Adverts", "PropertyTypeId", "dbo.PropertyTypes");
            DropIndex("dbo.Qualifications", new[] { "AdvertId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Adverts", new[] { "UserId" });
            DropIndex("dbo.Adverts", new[] { "AdvertTypeId" });
            DropIndex("dbo.Adverts", new[] { "HeatingId" });
            DropIndex("dbo.Adverts", new[] { "RoomId" });
            DropIndex("dbo.Adverts", new[] { "DistrictId" });
            DropIndex("dbo.Adverts", new[] { "CityId" });
            DropIndex("dbo.Adverts", new[] { "SellingTypeId" });
            DropIndex("dbo.Adverts", new[] { "PropertyTypeId" });
            DropTable("dbo.Qualifications");
            DropTable("dbo.Images");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.SellingTypes");
            DropTable("dbo.Rooms");
            DropTable("dbo.Heatings");
            DropTable("dbo.Districts");
            DropTable("dbo.AdvertTypes");
            DropTable("dbo.Cities");
            DropTable("dbo.PropertyTypes");
            DropTable("dbo.Adverts");
        }
    }
}

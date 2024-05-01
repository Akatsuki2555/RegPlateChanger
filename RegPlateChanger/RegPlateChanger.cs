using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using MSCLoader;
using UnityEngine;

namespace RegPlateChanger
{
    public class RegPlateChanger : Mod
    {
        public override string Name => "Plate Changer";
        public override string ID => "RegPlateChanger";
        public override string Version => "1.1";
        public override string Author => "アカツキ";

        public override bool UseAssetsFolder => true;

        public override void ModSetup()
        {
            base.ModSetup();

            SetupFunction(Setup.OnLoad, Mod_Load);
        }

        private void Mod_Load()
        {
            ApplySatsuma();
            ApplyHayosiko();
            ApplyFerndale();
            ApplyGifu();
            ApplyFittan();
            ApplyKekmet();

            // Highway
            ApplyHighwayGifu();
            ApplyHighwaySvoboda();
            ApplyHighwayLamore1();
            ApplyHighwayLamore2();
            ApplyHighwayVictro1();
            ApplyHighwayVictro2();
            ApplyHighwayVictro3();
            ApplyHighwayMenace();
            ApplyHighwayFittan();
            ApplyHighwayPolsa();

            // OTHER AI
            ApplyKylajani();
            ApplyAmis2();
            ApplyBus();
            ApplyKuski();

            // Police
            ApplyPoliceCar1();
            ApplyPoliceCar2();
        }

        private void ApplyPoliceCar1()
        {
            var frontPlate = GameObject.Find("TRAFFIC").C(9).C(0).C(0).C(6).C(15).C(4).C(0).GetComponent<Renderer>();
            var backPlate = GameObject.Find("TRAFFIC").C(9).C(0).C(0).C(6).C(15).C(4).C(1).GetComponent<Renderer>();

            if (TexExists("police_car_1_front.png"))
                frontPlate.sharedMaterial.mainTexture = LoadTex("police_car_1_front.png");
            if (TexExists("police_car_1_back.png"))
                backPlate.sharedMaterial.mainTexture = LoadTex("police_car_1_back.png");
        }

        private void ApplyPoliceCar2()
        {
            var frontPlate = GameObject.Find("TRAFFIC").C(9).C(0).C(0).C(3).C(15).C(4).C(0).GetComponent<Renderer>();
            var backPlate = GameObject.Find("TRAFFIC").C(9).C(0).C(0).C(3).C(15).C(4).C(1).GetComponent<Renderer>();

            if (TexExists("police_car_2_front.png"))
                frontPlate.sharedMaterial.mainTexture = LoadTex("police_car_2_front.png");
            if (TexExists("police_car_2_back.png"))
                backPlate.sharedMaterial.mainTexture = LoadTex("police_car_2_back.png");
        }

        private void ApplyKekmet()
        {
            var plate = GameObject.Find("KEKMET(350-400psi)").C(5).C(13).GetComponent<Renderer>();

            if (TexExists("kekmet.png")) plate.sharedMaterial.mainTexture = LoadTex("kekmet.png");
        }

        private void ApplyBus()
        {
            var npcCars = GameObject.Find("NPC_CARS");

            for (int i = 0; i < 3; i++)
            {
                if (npcCars.C(i).transform.childCount == 0) continue;
                var frontPlate = GameObject.Find("NPC_CARS").C(i).C(0).C(19).C(24).GetComponent<Renderer>();
                var backPlate = GameObject.Find("NPC_CARS").C(i).C(0).C(19).C(25).GetComponent<Renderer>();

                if (TexExists("bus_front.png")) frontPlate.sharedMaterial.mainTexture = LoadTex("bus_front.png");
                if (TexExists("bus_back.png")) backPlate.sharedMaterial.mainTexture = LoadTex("bus_back.png");
            }
        }

        private void ApplyKuski()
        {
            var frontPlate = GameObject.Find("NPC_CARS").C(3).C(19).C(10).GetComponent<Renderer>();
            var backPlate = GameObject.Find("NPC_CARS").C(3).C(19).C(11).GetComponent<Renderer>();

            if (TexExists("kuski_front.png")) frontPlate.sharedMaterial.mainTexture = LoadTex("kuski_front.png");
            if (TexExists("kuski_back.png")) backPlate.sharedMaterial.mainTexture = LoadTex("kuski_back.png");
        }

        private void ApplyKylajani()
        {
            var frontPlate = GameObject.Find("NPC_CARS").C(4).C(1).C(19).C(14).GetComponent<Renderer>();
            var backPlate = GameObject.Find("NPC_CARS").C(4).C(1).C(19).C(15).GetComponent<Renderer>();

            if (TexExists("kylajani_front.png")) frontPlate.sharedMaterial.mainTexture = LoadTex("kylajani_front.png");
            if (TexExists("kylajani_back.png")) backPlate.sharedMaterial.mainTexture = LoadTex("kylajani_back.png");
        }

        private void ApplyAmis2()
        {
            var frontPlate = GameObject.Find("NPC_CARS").C(4).C(0).C(17).C(9).GetComponent<Renderer>();
            var backPlate = GameObject.Find("NPC_CARS").C(4).C(0).C(17).C(10).GetComponent<Renderer>();

            if (TexExists("amis2_front.png")) frontPlate.sharedMaterial.mainTexture = LoadTex("amis2_front.png");
            if (TexExists("amis2_back.png")) backPlate.sharedMaterial.mainTexture = LoadTex("amis2_back.png");
        }

        private void ApplyHighwayPolsa()
        {
            var frontPlate = GameObject.Find("TRAFFIC").C(7).C(9).C(15).C(0).C(0).GetComponent<Renderer>();
            var backPlate = GameObject.Find("TRAFFIC").C(7).C(9).C(15).C(0).C(1).GetComponent<Renderer>();
            var caravanPlate = GameObject.Find("TRAFFIC").C(7).C(9).C(0).C(9).GetComponent<Renderer>();

            if (TexExists("highway_polsa_front.png"))
                frontPlate.sharedMaterial.mainTexture = LoadTex("highway_polsa_front.png");
            if (TexExists("highway_polsa_back.png"))
                backPlate.sharedMaterial.mainTexture = LoadTex("highway_polsa_back.png");
            if (TexExists("highway_polsa_caravan.png"))
                caravanPlate.sharedMaterial.mainTexture = LoadTex("highway_polsa_caravan.png");
        }

        private void ApplyHighwayFittan()
        {
            var frontPlate = GameObject.Find("TRAFFIC").C(7).C(8).C(18).C(13).C(0).GetComponent<Renderer>();
            var backPlate = GameObject.Find("TRAFFIC").C(7).C(8).C(18).C(13).C(1).GetComponent<Renderer>();

            if (TexExists("highway_fittan_front.png"))
                frontPlate.sharedMaterial.mainTexture = LoadTex("highway_fittan_front.png");
            if (TexExists("highway_fittan_back.png"))
                backPlate.sharedMaterial.mainTexture = LoadTex("highway_fittan_back.png");
        }

        private void ApplyHighwayMenace()
        {
            var frontPlate = GameObject.Find("TRAFFIC").C(7).C(7).C(17).C(8).C(0).GetComponent<Renderer>();
            var backPlate = GameObject.Find("TRAFFIC").C(7).C(7).C(17).C(8).C(1).GetComponent<Renderer>();

            if (TexExists("highway_menace_front.png"))
                frontPlate.sharedMaterial.mainTexture = LoadTex("highway_menace_front.png");
            if (TexExists("highway_menace_back.png"))
                backPlate.sharedMaterial.mainTexture = LoadTex("highway_menace_back.png");
        }

        private void ApplyHighwayVictro1()
        {
            var frontPlate = GameObject.Find("TRAFFIC").C(7).C(4).C(15).C(4).C(0).GetComponent<Renderer>();
            var backPlate = GameObject.Find("TRAFFIC").C(7).C(4).C(15).C(4).C(1).GetComponent<Renderer>();

            if (TexExists("highway_victro_1_front.png"))
                frontPlate.sharedMaterial.mainTexture = LoadTex("highway_victro_1_front.png");
            if (TexExists("highway_victro_1_back.png"))
                backPlate.sharedMaterial.mainTexture = LoadTex("highway_victro_1_back.png");
        }

        private void ApplyHighwayVictro2()
        {
            var frontPlate = GameObject.Find("TRAFFIC").C(7).C(5).C(15).C(4).C(0).GetComponent<Renderer>();
            var backPlate = GameObject.Find("TRAFFIC").C(7).C(5).C(15).C(4).C(1).GetComponent<Renderer>();

            if (TexExists("highway_victro_2_front.png"))
                frontPlate.sharedMaterial.mainTexture = LoadTex("highway_victro_2_front.png");
            if (TexExists("highway_victro_2_back.png"))
                backPlate.sharedMaterial.mainTexture = LoadTex("highway_victro_2_back.png");
        }

        private void ApplyHighwayVictro3()
        {
            var frontPlate = GameObject.Find("TRAFFIC").C(7).C(6).C(15).C(4).C(0).GetComponent<Renderer>();
            var backPlate = GameObject.Find("TRAFFIC").C(7).C(6).C(15).C(4).C(1).GetComponent<Renderer>();

            if (TexExists("highway_victro_3_front.png"))
                frontPlate.sharedMaterial.mainTexture = LoadTex("highway_victro_3_front.png");
            if (TexExists("highway_victro_3_back.png"))
                backPlate.sharedMaterial.mainTexture = LoadTex("highway_victro_3_back.png");
        }

        private void ApplyHighwayLamore2()
        {
            var frontPlate = GameObject.Find("TRAFFIC").C(7).C(3).C(15).C(4).C(0).GetComponent<Renderer>();
            var backPlate = GameObject.Find("TRAFFIC").C(7).C(3).C(15).C(4).C(1).GetComponent<Renderer>();

            if (TexExists("highway_lamore_2_front.png"))
                frontPlate.sharedMaterial.mainTexture = LoadTex("highway_lamore_2_front.png");
            if (TexExists("highway_lamore_2_back.png"))
                backPlate.sharedMaterial.mainTexture = LoadTex("highway_lamore_2_back.png");
        }

        private void ApplyHighwayLamore1()
        {
            var frontPlate = GameObject.Find("TRAFFIC").C(7).C(2).C(15).C(4).C(0).GetComponent<Renderer>();
            var backPlate = GameObject.Find("TRAFFIC").C(7).C(2).C(15).C(4).C(1).GetComponent<Renderer>();

            if (TexExists("highway_lamore_1_front.png"))
                frontPlate.sharedMaterial.mainTexture = LoadTex("highway_lamore_1_front.png");
            if (TexExists("highway_lamore_1_back.png"))
                backPlate.sharedMaterial.mainTexture = LoadTex("highway_lamore_1_back.png");
        }

        private void ApplyHighwaySvoboda()
        {
            var frontPlate = GameObject.Find("TRAFFIC").C(7).C(1).C(10).C(8).C(0).GetComponent<Renderer>();
            var backPlate = GameObject.Find("TRAFFIC").C(7).C(1).C(10).C(8).C(1).GetComponent<Renderer>();

            if (TexExists("highway_svoboda_front.png"))
                frontPlate.sharedMaterial.mainTexture = LoadTex("highway_svoboda_front.png");
            if (TexExists("highway_svoboda_back.png"))
                backPlate.sharedMaterial.mainTexture = LoadTex("highway_svoboda_back.png");
        }

        private void ApplyHighwayGifu()
        {
            var frontPlate = GameObject.Find("TRAFFIC").C(7).C(0).C(14).C(19).C(0).GetComponent<Renderer>();
            var backPlate = GameObject.Find("TRAFFIC").C(7).C(0).C(14).C(19).C(1).GetComponent<Renderer>();

            if (TexExists("highway_gifu_front.png"))
                frontPlate.sharedMaterial.mainTexture = LoadTex("highway_gifu_front.png");
            if (TexExists("highway_gifu_back.png"))
                backPlate.sharedMaterial.mainTexture = LoadTex("highway_gifu_back.png");
        }

        private void ApplyFittan()
        {
            var frontPlate = GameObject.Find("TRAFFIC").C(8).C(0).C(0).C(21).C(11).GetComponent<Renderer>();
            var backPlate = GameObject.Find("TRAFFIC").C(8).C(0).C(0).C(21).C(12).GetComponent<Renderer>();

            if (TexExists("fittan_front.png")) frontPlate.sharedMaterial.mainTexture = LoadTex("fittan_front.png");
            if (TexExists("fittan_back.png")) backPlate.sharedMaterial.mainTexture = LoadTex("fittan_back.png");
        }

        private void ApplySatsuma()
        {
            var frontPlate = GameObject.Find("INSPECTION").C(3).C(2).GetComponent<Renderer>();
            var backPlate = GameObject.Find("INSPECTION").C(3).C(3).GetComponent<Renderer>();

            if (TexExists("satsuma_front.png")) frontPlate.sharedMaterial.mainTexture = LoadTex("satsuma_front.png");
            if (TexExists("satsuma_back.png")) backPlate.sharedMaterial.mainTexture = LoadTex("satsuma_back.png");
        }

        private void ApplyGifu()
        {
            var frontPlate = GameObject.Find("GIFU(750/450psi)").C(11).C(3).GetComponent<Renderer>();
            var backPlate = GameObject.Find("GIFU(750/450psi)").C(11).C(4).GetComponent<Renderer>();

            if (TexExists("gifu_front.png")) frontPlate.sharedMaterial.mainTexture = LoadTex("gifu_front.png");
            if (TexExists("gifu_back.png")) backPlate.sharedMaterial.mainTexture = LoadTex("gifu_back.png");
        }

        private void ApplyHayosiko()
        {
            var frontPlate = GameObject.Find("HAYOSIKO(1500kg, 250)").C(6).C(14).GetComponent<Renderer>();
            var backPlate = GameObject.Find("HAYOSIKO(1500kg, 250)").C(13).C(0).C(3).GetComponent<Renderer>();

            if (TexExists("hayosiko_front.png")) frontPlate.sharedMaterial.mainTexture = LoadTex("hayosiko_front.png");
            if (TexExists("hayosiko_back.png")) backPlate.sharedMaterial.mainTexture = LoadTex("hayosiko_back.png");
        }

        private void ApplyFerndale()
        {
            var frontPlate = GameObject.Find("FERNDALE(1630kg)").C(1).C(11).GetComponent<Renderer>();
            var backPlate = GameObject.Find("FERNDALE(1630kg)").C(1).C(12).GetComponent<Renderer>();

            if (TexExists("ferndale_front.png")) frontPlate.sharedMaterial.mainTexture = LoadTex("ferndale_front.png");
            if (TexExists("ferndale_back.png")) backPlate.sharedMaterial.mainTexture = LoadTex("ferndale_back.png");
        }

        private bool TexExists(string fileName) =>
            File.Exists(Path.Combine(ModLoader.GetModAssetsFolder(this), fileName));

        private Texture2D LoadTex(string fileName)
        {
            if (!File.Exists(Path.Combine(ModLoader.GetModAssetsFolder(this), fileName)))
            {
                ModConsole.Warning($"File not found: {fileName}");
                return Texture2D.blackTexture;
            }

            var texture = new Texture2D(2, 2);
            texture.LoadImage(File.ReadAllBytes(Path.Combine(ModLoader.GetModAssetsFolder(this), fileName)));
            return texture;
        }
    }
}
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VentileClient.JSON_Template_Classes;
using VentileClient.Utils;

namespace VentileClient.LauncherUtils
{
    public static class CosmeticManager
    {
        static MainWindow MAIN = MainWindow.INSTANCE;
        static string MC_RESOURCE = MAIN.minecraftResourcePacks;
        static string GLOBAL_RESOURCE_PACKS = Path.Combine(MC_RESOURCE, @"..", @"minecraftpe\global_resource_packs.json");

        public static List<Cosmetic> Packs()
        {
            if (!File.Exists(GLOBAL_RESOURCE_PACKS))
            {
                Notif.Toast("Pack Error", "Looks like your com.mojang folder isnt avaliable!");
                return new List<Cosmetic>();
            }

            string json = File.ReadAllText(GLOBAL_RESOURCE_PACKS);

            return JsonConvert.DeserializeObject<List<Cosmetic>>(json);
        }

        public static bool IsEnabled(string id)
        {
            if (!File.Exists(GLOBAL_RESOURCE_PACKS)) return false;

            List<Cosmetic> jsonObject = Packs();

            for (int i = 0; i < jsonObject.Count; i++)
            {
                if (jsonObject[i].pack_id == id)
                {
                    return true;
                }
            }

            return false;
        }

        public static void Add(Pack pack)
        {
            if (!File.Exists(GLOBAL_RESOURCE_PACKS)) return;

            string id = PACK_INFO.ElementAt((int)pack).Key;

            if (!IsEnabled(id))
            {
                List<Cosmetic> packs = Packs();
                if (packs.Count < 1) return;

                if (id == PACK_INFO.ElementAt(16).Key)
                {
                    packs.Insert(0, new Cosmetic()
                    {
                        pack_id = id,
                        version = new int[] { 6, 0, 0 }
                    });
                }
                else
                {
                    packs.Insert(0, new Cosmetic()
                    {
                        pack_id = id,
                        version = PACK_INFO[id]
                    });
                }


                File.WriteAllText(GLOBAL_RESOURCE_PACKS, JsonConvert.SerializeObject(packs, Formatting.Indented));
            }
        }

        public static void Remove(Pack pack)
        {
            if (!File.Exists(GLOBAL_RESOURCE_PACKS)) return;

            string id = PACK_INFO.ElementAt((int)pack).Key;

            if (IsEnabled(id))
            {
                List<Cosmetic> packs = Packs();
                if (packs.Count < 1) return;

                for (int i = 0; i < packs.Count; i++)
                {
                    if (packs[i].pack_id == id)
                    {
                        packs.RemoveAt(i);
                    }
                }

                File.WriteAllText(GLOBAL_RESOURCE_PACKS, JsonConvert.SerializeObject(packs, Formatting.Indented));
            }
        }

        public static readonly Dictionary<string, int[]> PACK_INFO = new Dictionary<string, int[]>
        {
            { "3256f0cd-498a-4f97-a7ca-89dbeeeee4b8", new int[]{1, 0, 0 } }, // Black Cape
            { "51fabcfb-0636-4aa6-a935-2c34add462e4", new int[]{1, 0, 0 } }, // White Cape
            { "f495127b-83db-4e35-b93e-6c7f4b046a0f", new int[]{1, 0, 0 } }, // Pink Cape
            { "de9c860b-3ca6-4f48-8d81-1c8f4c65b8e9", new int[]{1, 0, 0 } }, // Blue Cape
            { "fc6bcc91-ee3c-4b97-bfcf-2243de323870", new int[]{1, 0, 0 } }, // Yellow Cape
            { "2fc8d46c-3652-4836-adfc-c1d2a43d5777", new int[]{1, 0, 0 } }, // Rick Cape

            { "982e6a3a-56f2-4e78-b0d5-b5eb9df0792b", new int[]{1, 0, 0 } }, // Black Mask
            { "03910601-ed59-4fb6-add5-f3b8cf27a8ff", new int[]{1, 0, 0 } }, // White Mask
            { "f4b600af-c2b3-43aa-b775-dec476f56829", new int[]{1, 0, 0 } }, // Pink Mask
            { "0af582ae-018f-47c4-92a9-db0643279fd0", new int[]{1, 0, 0 } }, // Blue Mask
            { "9891cbf5-d3d4-4d2d-94d9-cfeea717c2f9", new int[]{1, 0, 0 } }, // Yellow Mask
            { "6f7a314a-ea8c-4da0-ba38-4af023a0762e", new int[]{1, 0, 0 } }, // Rick Mask

            { "ed7b6991-50af-42c7-b302-84543a97e72b", new int[]{1, 0, 0 } }, // Glowing Cape
            { "57c6383e-7cb8-40b8-88af-8cbc18707c63", new int[]{1, 0, 0 } }, // Sliding Cape

            { "a6953918-a86c-43bb-a3af-ae6377bdba63", new int[]{1, 0, 0 } }, // Wavy Capes
            { "64564ae0-011b-4c2f-a87d-449c8119f234", new int[]{1, 0, 0 } }, // Animated Kagune

            { "b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e", new int[]{1, 0, 0 } } // Cosmetic Mixer
        };

        public enum Pack
        {
            BlackCape = 0,
            WhiteCape = 1,
            PinkCape = 2,
            BlueCape = 3,
            YellowCape = 4,
            RickCape = 5,

            BlackMask = 6,
            WhiteMask = 7,
            PinkMask = 8,
            BlueMask = 9,
            YellowMask = 10,
            RickMask = 11,

            GlowingCape = 12,
            SlidingCape = 13,

            WavyOverlay = 14,
            Kagune = 15,

            CosmeticMixer = 16,
        }
    }
}

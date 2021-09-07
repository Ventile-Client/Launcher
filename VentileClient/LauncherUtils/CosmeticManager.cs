using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentileClient.JSON_Template_Classes;
using VentileClient.Utils;

namespace VentileClient.LauncherUtils
{
    public static class CosmeticManager
    {
        static MainWindow MAIN = MainWindow.INSTANCE;
        static string MC_RESOURCE = MAIN.minecraftResourcePacks;

        public static List<CosmeticsObject> Packs()
        {
            if (!File.Exists(Path.Combine(MC_RESOURCE, @"..", @"minecraftpe\global_resource_packs.json")))
            {

                Notif.Toast("Pack Error", "Looks like your com.mojang folder isnt avaliable!");
                return new List<CosmeticsObject>();

            }

            string json = File.ReadAllText(Path.Combine(MC_RESOURCE, @"..", @"minecraftpe\global_resource_packs.json"));

            return JsonConvert.DeserializeObject<List<CosmeticsObject>>(json);
        }

        public static bool IsEnabled(string id)
        {
            if (!File.Exists(Path.Combine(MC_RESOURCE, @"..", @"minecraftpe\global_resource_packs.json"))) return false;

            string json = File.ReadAllText(Path.Combine(MC_RESOURCE, @"..", @"minecraftpe\global_resource_packs.json"));

            List<CosmeticsObject> jsonObject = JsonConvert.DeserializeObject<List<CosmeticsObject>>(json);

            bool enabled = false;

            for (int i = 0; i < jsonObject.Count; i++)
            {
                if (jsonObject[i].Pack_id == id)
                {
                    enabled = true;
                }
            }

            return enabled;
        }

        public static void Add(string id)
        {
            if (!File.Exists(Path.Combine(MC_RESOURCE, @"..", @"minecraftpe\global_resource_packs.json"))) return;

            if (!IsEnabled(id))
            {
                List<CosmeticsObject> packs = Packs();

                if (packs[0].Pack_id == "error") return;

                if (id == "b6039dbe-c5f1-4544-afdb-dd4b9ed7d19e")
                {
                    packs.Insert(0, new CosmeticsObject()
                    {
                        Pack_id = id,
                        Version = new int[] { 6, 0, 0 }
                    });
                }
                else
                {
                    packs.Insert(0, new CosmeticsObject()
                    {
                        Pack_id = id,
                        Version = PACK_INFO[id]
                    });
                }


                File.WriteAllText(Path.Combine(MC_RESOURCE, @"..", @"minecraftpe\global_resource_packs.json"), JsonConvert.SerializeObject(packs, Formatting.Indented));
            }
        }

        public static void Remove(string id)
        {
            if (!File.Exists(Path.Combine(MC_RESOURCE, @"..", @"minecraftpe\global_resource_packs.json"))) return;

            if (IsEnabled(id))
            {
                List<CosmeticsObject> packs = Packs();

                if (packs[0].Pack_id == "error") return;

                for (int i = 0; i < packs.Count; i++)
                {
                    if (packs[i].Pack_id == id)
                    {
                        packs.RemoveAt(i);
                    }
                }

                File.WriteAllText(Path.Combine(MC_RESOURCE, @"..", @"minecraftpe\global_resource_packs.json"), JsonConvert.SerializeObject(packs, Formatting.Indented));
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
    }
}

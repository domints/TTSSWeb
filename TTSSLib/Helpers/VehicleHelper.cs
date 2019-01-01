using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTSSLib.Models.API;
using TTSSLib.Models.Data;
using TTSSLib.Models.Enums;

namespace TTSSLib.Helpers
{
    internal static class VehicleHelper
    {
        public static Vehicle GetVehicle(this StopPassage passage)
        {
            if (string.IsNullOrWhiteSpace(passage.VehicleID))
                return null;

            var vehicle = new Vehicle
            {
                RawId = passage.VehicleID
            };

            var guessed = false;

            int id = 0;
            string prefix = string.Empty;
            string type = string.Empty;
            VehicleFloorType floorType = VehicleFloorType.Low;
            if(passage.VehicleID.Substring(0, 15) == "635218529567218")
            {
                id = int.Parse(passage.VehicleID.Substring(15)) - 736;
            }
            else if(passage.VehicleID.Substring(0, 3) == "-11")
            {
                var gid = VehicleGuessBase.GuessId(passage.VehicleID);
                if(!gid.HasValue)
                    return vehicle;
                
                id = gid.Value;
                guessed = true;
            }
            else
                return vehicle;

            if (id == 831)
            {
                id = 216;
            }

            if (101 <= id && id <= 174)
            {
                prefix = "HW";
                type = "E1";
                floorType = VehicleFloorType.High;

                if ((108 <= id && id <= 113) || id == 127 || id == 131 || id == 132 || id == 134 || (137 <= id && id <= 139) || (148 <= id && id <= 150) || (153 <= id && id <= 155))
                {
                    prefix = "RW";
                }
            }
            else if (201 <= id && id <= 293)
            {
                prefix = "RZ";
                type = "105Na";
                floorType = VehicleFloorType.High;

                if (246 <= id)
                {
                    prefix = "HZ";
                }
                if (id == 290)
                {
                    type = "105Nb";
                }
            }
            else if (301 <= id && id <= 328)
            {
                prefix = "RF";
                type = "GT8S";
                floorType = VehicleFloorType.High;

                if (id == 313)
                {
                    type = "GT8C";
                    floorType = VehicleFloorType.PartiallyLow;
                }
                else if (id == 323)
                {
                    floorType = VehicleFloorType.PartiallyLow;
                }
            }
            else if (401 <= id && id <= 440)
            {
                prefix = "HL";
                type = "EU8N";
                floorType = VehicleFloorType.PartiallyLow;
            }
            else if (451 <= id && id <= 462)
            {
                prefix = "HK";
                type = "N8S-NF";
                floorType = VehicleFloorType.PartiallyLow;

                if ((451 <= id && id <= 456) || id == 462)
                {
                    type = "N8C-NF";
                }
            }
            else if (601 <= id && id <= 650)
            {
                prefix = "RP";
                type = "NGT6 (3)";
                floorType = VehicleFloorType.Low;

                if (id <= 613)
                {
                    type = "NGT6 (1)";
                }
                else if (id <= 626)
                {
                    type = "NGT6 (2)";
                }
            }
            else if (801 <= id && id <= 824)
            {
                prefix = "RY";
                type = "NGT8";
                floorType = VehicleFloorType.Low;
            }
            else if (id == 899)
            {
                prefix = "RY";
                type = "126N";
                floorType = VehicleFloorType.Low;
            }
            else if (901 <= id && id <= 936)
            {
                prefix = "RG";
                type = "2014N";
                floorType = VehicleFloorType.Low;

                if (915 <= id)
                {
                    prefix = "HG";
                }
            }
            else if (id == 999)
            {
                prefix = "HG";
                type = "405N-Kr";
                floorType = VehicleFloorType.PartiallyLow;
            }
            else
            {
                return null;
            }

            vehicle.SideNo = $"{(guessed ? "(???) " : "")}{prefix}{id}";
            vehicle.FloorType = floorType;
            vehicle.ID = id;
            vehicle.ModelName = type;
            return vehicle;
        }

        public static string GetTTSSIdFromOur(int id)
        {
            if (id == 216) id = 831;

            return $"635218529567218{id + 736}";
        }
    }
}

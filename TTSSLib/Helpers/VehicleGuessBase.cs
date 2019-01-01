using System;
using System.Collections.Generic;
using System.Linq;

namespace TTSSLib.Helpers
{
    public static class VehicleGuessBase
    {
        const string data = @"HW107,-1188950297304569380,2018-12-21 17:27:06.686254,17257793776404982236
HW120,-1188950297304569332,2018-12-21 13:45:51.15802,17257793776404982284
HW130,-1188950297304569296,2018-12-21 20:11:33.84731,17257793776404982320
HW145,-1188950297304569240,2018-12-21 10:46:50.923997,17257793776404982376
HW150,-1188950297304569220,2018-12-21 17:27:59.809061,17257793776404982396
HZ252,-1188950297304569041,2018-12-21 13:47:07.505781,17257793776404982575
RF302,-1188950297304568972,2018-12-21 12:50:04.541213,17257793776404982644
RF321,-1188950297304568895,2018-12-21 17:19:29.531925,17257793776404982721
HL405,-1188950297304572311,2018-12-21 10:41:52.351151,17257793776404979305
HL411,-1188950297304568829,2018-12-21 11:47:13.390444,17257793776404982787
RP606,-1188950297304568627,2018-12-21 20:12:49.857109,17257793776404982989
RP612,-1188950297304568602,2018-12-21 20:18:47.329114,17257793776404983014
RP612,-1188950297304568602,2018-12-21 12:47:26.159115,17257793776404983014
RP630,-1188950297304568542,2018-12-21 13:46:58.881935,17257793776404983074
RP630,-1188950297304568542,2018-12-21 17:19:44.945459,17257793776404983074
RP635,-1188950297304568522,2018-12-21 13:46:32.140042,17257793776404983094
RP637,-1188950297304568513,2018-12-21 17:23:20.12893,17257793776404983103
RP638,-1188950297304572320,2018-12-21 20:17:21.474134,17257793776404979296
RP645,-1188950297304568489,2018-12-21 17:30:35.122926,17257793776404983127
RP646,-1188950297304568485,2018-12-21 20:25:55.883336,17257793776404983131
RP650,-1188950297304568477,2018-12-21 10:45:58.989799,17257793776404983139
RG903,-1188950297304568377,2018-12-21 20:10:18.000152,17257793776404983239
RG905,-1188950297304568369,2018-12-21 12:48:52.41289,17257793776404983247
RG905,-1188950297304568273,2018-12-21 11:47:37.071495,17257793776404983343
RG905,-1188950297304568369,2018-12-21 13:48:11.594824,17257793776404983247
RG908,-1188950297304568357,2018-12-21 17:19:59.086338,17257793776404983259
HG936,-1188950297304572340,2018-12-21 11:48:33.815167,17257793776404979276
HG936,-1188950297304572340,2018-12-21 11:48:36.292405,17257793776404979276
HG936,-1188950297304572340,2018-12-21 10:46:25.472506,17257793776404979276
HL401,-1188950297300582888,2018-12-26 11:14:29.968218,17257793776408968728
RP612,-1188950297300579444,2018-12-26 11:18:13.734865,17257793776408972172
HG935,-1188950297300579084,2018-12-26 11:10:59.429747,17257793776408972532
HW103,-1188950297296462967,2018-12-31 17:53:53.356637,17257793776413088649
HW104,-1188950297296457300,2018-12-31 17:46:49.645115,17257793776413094316
HW104,-1188950297296457300,2018-12-31 17:00:31.429384,17257793776413094316
HW104,-1188950297296457300,2018-12-31 17:46:55.564294,17257793776413094316
HW104,-1188950297296457300,2018-12-31 17:46:43.484722,17257793776413094316
HW106,-1188950297296457292,2018-12-31 17:17:58.067349,17257793776413094324
RW109,-1188950297296457280,2018-12-31 17:08:00.203306,17257793776413094336
RW109,-1188950297296457280,2018-12-31 17:53:31.14783,17257793776413094336
RW110,-1188950297296457276,2018-12-31 17:07:19.366209,17257793776413094340
HW116,-1188950297296457252,2018-12-31 17:03:57.113599,17257793776413094364
HW121,-1188950297296457232,2018-12-31 17:36:31.586664,17257793776413094384
HW121,-1188950297296457232,2018-12-31 16:55:50.765682,17257793776413094384
HW124,-1188950297296457220,2018-12-31 17:13:40.79899,17257793776413094396
RW127,-1188950297296457208,2018-12-31 17:46:22.942996,17257793776413094408
RW127,-1188950297296457208,2018-12-31 17:46:31.564231,17257793776413094408
HW130,-1188950297296457196,2018-12-31 17:32:00.430885,17257793776413094420
HW135,-1188950297296457176,2018-12-31 16:53:06.538303,17257793776413094440
HW135,-1188950297296457176,2018-12-31 17:51:39.815757,17257793776413094440
HW137,-1188950297296457168,2018-12-31 17:21:41.010267,17257793776413094448
RW139,-1188950297296457160,2018-12-31 17:11:42.972803,17257793776413094456
HW142,-1188950297296457148,2018-12-31 17:44:40.272365,17257793776413094468
HW143,-1188950297296457144,2018-12-31 17:39:52.129803,17257793776413094472
HW145,-1188950297296457136,2018-12-31 17:14:07.434959,17257793776413094480
HW146,-1188950297296457132,2018-12-31 17:38:11.926565,17257793776413094484
HW147,-1188950297296457128,2018-12-31 17:07:32.986212,17257793776413094488
HW151,-1188950297296457112,2018-12-31 17:06:54.490321,17257793776413094504
HW156,-1188950297296457092,2018-12-31 17:36:49.503842,17257793776413094524
HW161,-1188950297296457072,2018-12-31 17:22:52.575404,17257793776413094544
RZ207,-1188950297296457016,2018-12-31 17:25:56.643619,17257793776413094600
RZ226,-1188950297296456980,2018-12-31 16:56:43.150916,17257793776413094636
HZ252,-1188950297296456932,2018-12-31 17:45:41.822571,17257793776413094684
HZ284,-1188950297296456884,2018-12-31 17:40:11.595157,17257793776413094732
HL412,-1188950297296456724,2018-12-31 17:41:17.352687,17257793776413094892
HL412,-1188950297296456724,2018-12-31 17:02:58.55085,17257793776413094892
HL422,-1188950297296456704,2018-12-31 17:47:20.233708,17257793776413094912
HL422,-1188950297296456704,2018-12-31 17:26:25.260082,17257793776413094912
HL424,-1188950297296456696,2018-12-31 17:10:33.370665,17257793776413094920
HL424,-1188950297296456696,2018-12-31 17:31:16.628672,17257793776413094920
HL433,-1188950297296463388,2018-12-31 17:17:32.01492,17257793776413088228
HL433,-1188950297296463388,2018-12-31 16:56:16.906246,17257793776413088228
RP602,-1188950297296456584,2018-12-31 17:02:37.483793,17257793776413095032
RP603,-1188950297296456580,2018-12-31 17:48:05.999666,17257793776413095036
RP605,-1188950297296456576,2018-12-31 17:10:19.487333,17257793776413095040
RP605,-1188950297296456576,2018-12-31 17:47:44.552162,17257793776413095040
RP607,-1188950297296456572,2018-12-31 17:57:42.385697,17257793776413095044
RP610,-1188950297296456560,2018-12-31 17:34:03.554494,17257793776413095056
RP611,-1188950297296456556,2018-12-31 17:28:45.714593,17257793776413095060
RP612,-1188950297296456552,2018-12-31 17:41:44.476401,17257793776413095064
RP618,-1188950297296456528,2018-12-31 17:06:15.992222,17257793776413095088
RP622,-1188950297296456512,2018-12-31 17:20:22.524624,17257793776413095104
RP628,-1188950297296456492,2018-12-31 18:02:34.234088,17257793776413095124
RP628,-1188950297296456492,2018-12-31 17:26:50.699706,17257793776413095124
RP629,-1188950297296456488,2018-12-31 17:33:02.258763,17257793776413095128
RP635,-1188950297296456461,2018-12-31 17:03:20.169087,17257793776413095155
RP639,-1188950297296456449,2018-12-31 17:32:51.548187,17257793776413095167
RP639,-1188950297296456449,2018-12-31 16:57:29.628829,17257793776413095167
RP642,-1188950297296456437,2018-12-31 17:17:45.846103,17257793776413095179
RP642,-1188950297296456437,2018-12-31 16:42:41.522692,17257793776413095179
RP644,-1188950297296456429,2018-12-31 17:43:42.650753,17257793776413095187
RP646,-1188950297296456421,2018-12-31 17:18:48.881172,17257793776413095195
RG910,-1188950297296456297,2018-12-31 17:28:28.164333,17257793776413095319
RG912,-1188950297296456289,2018-12-31 17:00:00.808573,17257793776413095327
HG920,-1188950297296456261,2018-12-31 17:37:36.199414,17257793776413095355
HG923,-1188950297296456249,2018-12-31 17:24:57.639448,17257793776413095367
HG924,-1188950297296460057,2018-12-31 16:55:15.518798,17257793776413091559
HG929,-1188950297296456233,2018-12-31 17:14:00.399624,17257793776413095383
HG933,-1188950297296462936,2018-12-31 17:22:32.426443,17257793776413088680";

        private static List<TramLog> savedEntries;

        public static int? GuessId(string vehicleId)
        {
            if (savedEntries == null)
            {
                InitEntries();
            }

            if (string.IsNullOrWhiteSpace(vehicleId))
                return null;

            long pId = 0;
            if (!long.TryParse(vehicleId, out pId))
                return null;

            TramLog result = null;
            long distance = long.MaxValue;

            foreach (var tl in savedEntries)
            {
                var d = Math.Abs(tl.ParsedId - pId);
                if (d < 400 && d < distance && d % 4 == 0)
                {
                    if (d == 0)
                    {
                        return tl.Id;
                    }

                    distance = d;
                    result = tl;
                }
            }

            if(result == null)
                return null;

            var realDist = result.ParsedId - pId;
            
            return (int)(result.Id - (realDist / 4));

        }

        private static void InitEntries()
        {
            savedEntries = new List<TramLog>();
            var values = data.Split('\n').Select(d => d.Trim().Split(',')).ToList();
            foreach (var v in values)
            {
                var tl = new TramLog();
                tl.Id = int.Parse(v[0].Substring(2));
                tl.TheirId = v[1];
                tl.ParsedId = long.Parse(v[1]);
                savedEntries.Add(tl);
            }
        }

        class TramLog
        {
            public int Id { get; set; }
            public string TheirId { get; set; }
            public long ParsedId { get; set; }
        }
    }
}
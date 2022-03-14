using System.Threading;

using RAGE;
using RAGE.Elements;

namespace bigmap
{
    class bigmap : Events.Script﻿
    {
       /* private int status = 0;
        private Timer timer = null;

        public bigmap()
        {
            RAGE.Game.Ui.SetRadarBigmapEnabled(false, false);
            RAGE.Game.Ui.Unknown._0x82CEDC33687E1F50(false);
            RAGE.Game.Ui.SetRadarZoom(1);

            Events.Tick += Tick;
        }
        public void Tick(System.Collections.Generic.List<Events.TickNametagData> nametags)
        {
            RAGE.Game.Pad.DisableControlAction(0, 48, true);
            if (RAGE.Game.Pad.IsDisabledControlJustPressed(0, 48))
            {
                if (status == 0)
                {
                    RAGE.Game.Ui.SetRadarZoom(0);
                    status = 1;

                    timer = new Timer((object unused) =>
                    {
                        RAGE.Game.Ui.SetRadarBigmapEnabled(false, true);
                        RAGE.Game.Ui.SetRadarZoom(1);

                        status = 0;
                        timer.Dispose();
                        timer = null;

                    }, null, 10000, Timeout.Infinite);
                }
                else if (status == 1)
                {
                    if (timer != null)
                    {
                        timer.Dispose();
                        timer = null;
                    }

                    RAGE.Game.Ui.SetRadarBigmapEnabled(true, false);
                    RAGE.Game.Ui.Unknown._0x82CEDC33687E1F50(true);
                    RAGE.Game.Ui.SetRadarZoom(0);
                    status = 2;

                    timer = new Timer((object unused) =>
                    {
                        RAGE.Game.Ui.SetRadarBigmapEnabled(false, true);
                        RAGE.Game.Ui.Unknown._0x82CEDC33687E1F50(false);
                        RAGE.Game.Ui.SetRadarZoom(1);

                        status = 0;
                        timer.Dispose();
                        timer = null;

                    }, null, 10000, Timeout.Infinite);
                }
                else
                {
                    if (timer != null)
                    {
                        timer.Dispose();
                        timer = null;
                    }

                    RAGE.Game.Ui.SetRadarBigmapEnabled(false, false);
                    RAGE.Game.Ui.Unknown._0x82CEDC33687E1F50(false);
                    RAGE.Game.Ui.SetRadarZoom(1);
                    status = 0;
                }
            }
        }*/
    }
}
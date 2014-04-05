WafermapDisplay
===============

c# project providing a wafer map control

This project aims to provide a way to visualize wafer map data in windows applications
A wafer map is something specific to semiconductor industry and usually the data is coming from Wafer Probe using ATE

A more detailed documentation is coming soon (as soon as I've got time to do it)

Basically the useage should be quite self explaining
In the meantime I'll just provide a snipped out of my test class:

            for (int waferNum = 0; waferNum < nrWafers; waferNum++)
            {
                // Create sample dataset
                int[,] data = new int[300, 300];
                Random binGenerator = new Random(waferNum);
                for (int x = 0; x < 300; x++)
                {
                    for (int y = 0; y < 300; y++)
                    {
                        data[x, y] = binGenerator.Next(8);
                    }
                }
                WafermapImpl wmap = new WafermapImpl();
                wmap.Dataset = data;
                wmap.Notchlocation = 90;
                wmap.MinimumSize = new Size(250,250);

                wmap.Interactive = true;
                //this.Controls.Add(wmap);
                flowLayoutPanel1.Controls.Add(wmap);
            }
            
Here's the implementation class:
       class WafermapImpl : Wafermap
        {

            public override void dieEntered(int x, int y, int bincode)
            {
                // Do nothing
            }

            public override void dieClicked(int x, int y, int bincode, System.Windows.Forms.MouseButtons btn)
            {
                // Cast

                if (btn == MouseButtons.Left)
                {
                    // Update dataset
                    Dataset[x, y] = 2;
                    // Show the changes
                    updateDie(x, y, 2);
                }
                else
                {
                    // Rotation test
                    int rot=Rotation + 90;
                    if (rot > 270)
                        rot = rot - 360;
                    Rotation = rot;
                    Invalidate();
                }
            }
        }
The 2 overwrittern methods get called by the Wafermap class when a die is clicked or when the mouse pointer enters 
a die in the visualization

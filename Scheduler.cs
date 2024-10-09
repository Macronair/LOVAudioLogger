using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MarcosIcecastRecorder
{
    public partial class frmScheduler : Form
    {
        private ListViewGroup Monday = new ListViewGroup("Monday", HorizontalAlignment.Left);
        private ListViewGroup Tuesday = new ListViewGroup("Tuesday", HorizontalAlignment.Left);
        private ListViewGroup Wednesday = new ListViewGroup("Wednesday", HorizontalAlignment.Left);
        private ListViewGroup Thursday = new ListViewGroup("Thursday", HorizontalAlignment.Left);
        private ListViewGroup Friday = new ListViewGroup("Friday", HorizontalAlignment.Left);
        private ListViewGroup Saturday = new ListViewGroup("Saturday", HorizontalAlignment.Left);
        private ListViewGroup Sunday = new ListViewGroup("Sunday", HorizontalAlignment.Left);

        public frmScheduler()
        {
            InitializeComponent();
        }

        private string GetProgramName(int day, int hour)
        {
            switch(day)
            {
                case 0:
                    switch(hour)
                    {
                        case 0:
                            return ProgramSchedule.Monday12PM;
                        case 1:
                            return ProgramSchedule.Monday1AM;
                        case 2:
                            return ProgramSchedule.Monday2AM;
                        case 3:
                            return ProgramSchedule.Monday3AM;
                        case 4:
                            return ProgramSchedule.Monday4AM;
                        case 5:
                            return ProgramSchedule.Monday5AM;
                        case 6:
                            return ProgramSchedule.Monday6AM;
                        case 7:
                            return ProgramSchedule.Monday7AM;
                        case 8:
                            return ProgramSchedule.Monday8AM;
                        case 9:
                            return ProgramSchedule.Monday9AM;
                        case 10:
                            return ProgramSchedule.Monday10AM;
                        case 11:
                            return ProgramSchedule.Monday11AM;
                        case 12:
                            return ProgramSchedule.Monday12AM;
                        case 13:
                            return ProgramSchedule.Monday1PM;
                        case 14:
                            return ProgramSchedule.Monday2PM;
                        case 15:
                            return ProgramSchedule.Monday3PM;
                        case 16:
                            return ProgramSchedule.Monday4PM;
                        case 17:
                            return ProgramSchedule.Monday5PM;
                        case 18:
                            return ProgramSchedule.Monday6PM;
                        case 19:
                            return ProgramSchedule.Monday7PM;
                        case 20:
                            return ProgramSchedule.Monday8PM;
                        case 21:
                            return ProgramSchedule.Monday9PM;
                        case 22:
                            return ProgramSchedule.Monday10PM;
                        case 23:
                            return ProgramSchedule.Monday11PM;
                        default:
                            return "";
                    }
                case 1:
                    switch (hour)
                    {
                        case 0:
                            return ProgramSchedule.Tuesday12PM;
                        case 1:
                            return ProgramSchedule.Tuesday1AM;
                        case 2:
                            return ProgramSchedule.Tuesday2AM;
                        case 3:
                            return ProgramSchedule.Tuesday3AM;
                        case 4:
                            return ProgramSchedule.Tuesday4AM;
                        case 5:
                            return ProgramSchedule.Tuesday5AM;
                        case 6:
                            return ProgramSchedule.Tuesday6AM;
                        case 7:
                            return ProgramSchedule.Tuesday7AM;
                        case 8:
                            return ProgramSchedule.Tuesday8AM;
                        case 9:
                            return ProgramSchedule.Tuesday9AM;
                        case 10:
                            return ProgramSchedule.Tuesday10AM;
                        case 11:
                            return ProgramSchedule.Tuesday11AM;
                        case 12:
                            return ProgramSchedule.Tuesday12AM;
                        case 13:
                            return ProgramSchedule.Tuesday1PM;
                        case 14:
                            return ProgramSchedule.Tuesday2PM;
                        case 15:
                            return ProgramSchedule.Tuesday3PM;
                        case 16:
                            return ProgramSchedule.Tuesday4PM;
                        case 17:
                            return ProgramSchedule.Tuesday5PM;
                        case 18:
                            return ProgramSchedule.Tuesday6PM;
                        case 19:
                            return ProgramSchedule.Tuesday7PM;
                        case 20:
                            return ProgramSchedule.Tuesday8PM;
                        case 21:
                            return ProgramSchedule.Tuesday9PM;
                        case 22:
                            return ProgramSchedule.Tuesday10PM;
                        case 23:
                            return ProgramSchedule.Tuesday11PM;
                        default:
                            return "";
                    }
                case 2:
                    switch (hour)
                    {
                        case 0:
                            return ProgramSchedule.Wednesday12PM;
                        case 1:
                            return ProgramSchedule.Wednesday1AM;
                        case 2:
                            return ProgramSchedule.Wednesday2AM;
                        case 3:
                            return ProgramSchedule.Wednesday3AM;
                        case 4:
                            return ProgramSchedule.Wednesday4AM;
                        case 5:
                            return ProgramSchedule.Wednesday5AM;
                        case 6:
                            return ProgramSchedule.Wednesday6AM;
                        case 7:
                            return ProgramSchedule.Wednesday7AM;
                        case 8:
                            return ProgramSchedule.Wednesday8AM;
                        case 9:
                            return ProgramSchedule.Wednesday9AM;
                        case 10:
                            return ProgramSchedule.Wednesday10AM;
                        case 11:
                            return ProgramSchedule.Wednesday11AM;
                        case 12:
                            return ProgramSchedule.Wednesday12AM;
                        case 13:
                            return ProgramSchedule.Wednesday1PM;
                        case 14:
                            return ProgramSchedule.Wednesday2PM;
                        case 15:
                            return ProgramSchedule.Wednesday3PM;
                        case 16:
                            return ProgramSchedule.Wednesday4PM;
                        case 17:
                            return ProgramSchedule.Wednesday5PM;
                        case 18:
                            return ProgramSchedule.Wednesday6PM;
                        case 19:
                            return ProgramSchedule.Wednesday7PM;
                        case 20:
                            return ProgramSchedule.Wednesday8PM;
                        case 21:
                            return ProgramSchedule.Wednesday9PM;
                        case 22:
                            return ProgramSchedule.Wednesday10PM;
                        case 23:
                            return ProgramSchedule.Wednesday11PM;
                        default:
                            return "";
                    }
                case 3:
                    switch (hour)
                    {
                        case 0:
                            return ProgramSchedule.Thursday12PM;
                        case 1:
                            return ProgramSchedule.Thursday1AM;
                        case 2:
                            return ProgramSchedule.Thursday2AM;
                        case 3:
                            return ProgramSchedule.Thursday3AM;
                        case 4:
                            return ProgramSchedule.Thursday4AM;
                        case 5:
                            return ProgramSchedule.Thursday5AM;
                        case 6:
                            return ProgramSchedule.Thursday6AM;
                        case 7:
                            return ProgramSchedule.Thursday7AM;
                        case 8:
                            return ProgramSchedule.Thursday8AM;
                        case 9:
                            return ProgramSchedule.Thursday9AM;
                        case 10:
                            return ProgramSchedule.Thursday10AM;
                        case 11:
                            return ProgramSchedule.Thursday11AM;
                        case 12:
                            return ProgramSchedule.Thursday12AM;
                        case 13:
                            return ProgramSchedule.Thursday1PM;
                        case 14:
                            return ProgramSchedule.Thursday2PM;
                        case 15:
                            return ProgramSchedule.Thursday3PM;
                        case 16:
                            return ProgramSchedule.Thursday4PM;
                        case 17:
                            return ProgramSchedule.Thursday5PM;
                        case 18:
                            return ProgramSchedule.Thursday6PM;
                        case 19:
                            return ProgramSchedule.Thursday7PM;
                        case 20:
                            return ProgramSchedule.Thursday8PM;
                        case 21:
                            return ProgramSchedule.Thursday9PM;
                        case 22:
                            return ProgramSchedule.Thursday10PM;
                        case 23:
                            return ProgramSchedule.Thursday11PM;
                        default:
                            return "";
                    }
                case 4:
                    switch (hour)
                    {
                        case 0:
                            return ProgramSchedule.Friday12PM;
                        case 1:
                            return ProgramSchedule.Friday1AM;
                        case 2:
                            return ProgramSchedule.Friday2AM;
                        case 3:
                            return ProgramSchedule.Friday3AM;
                        case 4:
                            return ProgramSchedule.Friday4AM;
                        case 5:
                            return ProgramSchedule.Friday5AM;
                        case 6:
                            return ProgramSchedule.Friday6AM;
                        case 7:
                            return ProgramSchedule.Friday7AM;
                        case 8:
                            return ProgramSchedule.Friday8AM;
                        case 9:
                            return ProgramSchedule.Friday9AM;
                        case 10:
                            return ProgramSchedule.Friday10AM;
                        case 11:
                            return ProgramSchedule.Friday11AM;
                        case 12:
                            return ProgramSchedule.Friday12AM;
                        case 13:
                            return ProgramSchedule.Friday1PM;
                        case 14:
                            return ProgramSchedule.Friday2PM;
                        case 15:
                            return ProgramSchedule.Friday3PM;
                        case 16:
                            return ProgramSchedule.Friday4PM;
                        case 17:
                            return ProgramSchedule.Friday5PM;
                        case 18:
                            return ProgramSchedule.Friday6PM;
                        case 19:
                            return ProgramSchedule.Friday7PM;
                        case 20:
                            return ProgramSchedule.Friday8PM;
                        case 21:
                            return ProgramSchedule.Friday9PM;
                        case 22:
                            return ProgramSchedule.Friday10PM;
                        case 23:
                            return ProgramSchedule.Friday11PM;
                        default:
                            return "";
                    }
                case 5:
                    switch (hour)
                    {
                        case 0:
                            return ProgramSchedule.Saturday12PM;
                        case 1:
                            return ProgramSchedule.Saturday1AM;
                        case 2:
                            return ProgramSchedule.Saturday2AM;
                        case 3:
                            return ProgramSchedule.Saturday3AM;
                        case 4:
                            return ProgramSchedule.Saturday4AM;
                        case 5:
                            return ProgramSchedule.Saturday5AM;
                        case 6:
                            return ProgramSchedule.Saturday6AM;
                        case 7:
                            return ProgramSchedule.Saturday7AM;
                        case 8:
                            return ProgramSchedule.Saturday8AM;
                        case 9:
                            return ProgramSchedule.Saturday9AM;
                        case 10:
                            return ProgramSchedule.Saturday10AM;
                        case 11:
                            return ProgramSchedule.Saturday11AM;
                        case 12:
                            return ProgramSchedule.Saturday12AM;
                        case 13:
                            return ProgramSchedule.Saturday1PM;
                        case 14:
                            return ProgramSchedule.Saturday2PM;
                        case 15:
                            return ProgramSchedule.Saturday3PM;
                        case 16:
                            return ProgramSchedule.Saturday4PM;
                        case 17:
                            return ProgramSchedule.Saturday5PM;
                        case 18:
                            return ProgramSchedule.Saturday6PM;
                        case 19:
                            return ProgramSchedule.Saturday7PM;
                        case 20:
                            return ProgramSchedule.Saturday8PM;
                        case 21:
                            return ProgramSchedule.Saturday9PM;
                        case 22:
                            return ProgramSchedule.Saturday10PM;
                        case 23:
                            return ProgramSchedule.Saturday11PM;
                        default:
                            return "";
                    }
                case 6:
                    switch (hour)
                    {
                        case 0:
                            return ProgramSchedule.Sunday12PM;
                        case 1:
                            return ProgramSchedule.Sunday1AM;
                        case 2:
                            return ProgramSchedule.Sunday2AM;
                        case 3:
                            return ProgramSchedule.Sunday3AM;
                        case 4:
                            return ProgramSchedule.Sunday4AM;
                        case 5:
                            return ProgramSchedule.Sunday5AM;
                        case 6:
                            return ProgramSchedule.Sunday6AM;
                        case 7:
                            return ProgramSchedule.Sunday7AM;
                        case 8:
                            return ProgramSchedule.Sunday8AM;
                        case 9:
                            return ProgramSchedule.Sunday9AM;
                        case 10:
                            return ProgramSchedule.Sunday10AM;
                        case 11:
                            return ProgramSchedule.Sunday11AM;
                        case 12:
                            return ProgramSchedule.Sunday12AM;
                        case 13:
                            return ProgramSchedule.Sunday1PM;
                        case 14:
                            return ProgramSchedule.Sunday2PM;
                        case 15:
                            return ProgramSchedule.Sunday3PM;
                        case 16:
                            return ProgramSchedule.Sunday4PM;
                        case 17:
                            return ProgramSchedule.Sunday5PM;
                        case 18:
                            return ProgramSchedule.Sunday6PM;
                        case 19:
                            return ProgramSchedule.Sunday7PM;
                        case 20:
                            return ProgramSchedule.Sunday8PM;
                        case 21:
                            return ProgramSchedule.Sunday9PM;
                        case 22:
                            return ProgramSchedule.Sunday10PM;
                        case 23:
                            return ProgramSchedule.Sunday11PM;
                        default:
                            return "";
                    }
                default:
                    return "";
            }
        }

        private void frmScheduler_Load(object sender, EventArgs e)
        {

            string[] strArrGroups = new string[] { "Monday", "Thursday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            string[] strArrItems = new string[] { "00:00", "01:00", "02:00", "03:00", "04:00", "05:00", "06:00", "07:00", "08:00"
                                                , "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00",
                                                  "18:00", "19:00", "20:00", "21:00", "22:00", "23:00"};
            for (int i = 0; i < strArrGroups.Length; i++)
            {
                int groupIndex = listScheduler.Groups.Add(new ListViewGroup(strArrGroups[i], HorizontalAlignment.Left));
                for (int j = 0; j < strArrItems.Length; j++)
                {
                    ListViewItem lvi = new ListViewItem(strArrItems[j]);
                    lvi.SubItems.Add(GetProgramName(i, j));
                    listScheduler.Items.Add(lvi);
                    listScheduler.Groups[i].Items.Add(lvi);
                }
            }
        }

        private void listScheduler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listScheduler.SelectedItems.Count > 0)
            {
                lblSelectedIndex.Text = "Selected Item: " + listScheduler.Items.IndexOf(listScheduler.SelectedItems[0]);
            }
        }

        private void listScheduler_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string item = listScheduler.SelectedItems[0].SubItems[1].Text;

            frmProgramName programName = new frmProgramName();
            programName.txtProgramName.Text = item;
            if(programName.ShowDialog () == DialogResult.OK)
            {
                listScheduler.SelectedItems[0].SubItems[1].Text = programName.txtProgramName.Text;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var program = new Programs
            {
                Monday12PM = listScheduler.Items[0].SubItems[1].Text,
                Monday1AM = listScheduler.Items[1].SubItems[1].Text,
                Monday2AM = listScheduler.Items[2].SubItems[1].Text,
                Monday3AM = listScheduler.Items[3].SubItems[1].Text,
                Monday4AM = listScheduler.Items[4].SubItems[1].Text,
                Monday5AM = listScheduler.Items[5].SubItems[1].Text,
                Monday6AM = listScheduler.Items[6].SubItems[1].Text,
                Monday7AM = listScheduler.Items[7].SubItems[1].Text,
                Monday8AM = listScheduler.Items[8].SubItems[1].Text,
                Monday9AM = listScheduler.Items[9].SubItems[1].Text,
                Monday10AM = listScheduler.Items[10].SubItems[1].Text,
                Monday11AM = listScheduler.Items[11].SubItems[1].Text,
                Monday12AM = listScheduler.Items[12].SubItems[1].Text,
                Monday1PM = listScheduler.Items[13].SubItems[1].Text,
                Monday2PM = listScheduler.Items[14].SubItems[1].Text,
                Monday3PM = listScheduler.Items[15].SubItems[1].Text,
                Monday4PM = listScheduler.Items[16].SubItems[1].Text,
                Monday5PM = listScheduler.Items[17].SubItems[1].Text,
                Monday6PM = listScheduler.Items[18].SubItems[1].Text,
                Monday7PM = listScheduler.Items[19].SubItems[1].Text,
                Monday8PM = listScheduler.Items[20].SubItems[1].Text,
                Monday9PM = listScheduler.Items[21].SubItems[1].Text,
                Monday10PM = listScheduler.Items[22].SubItems[1].Text,
                Monday11PM = listScheduler.Items[23].SubItems[1].Text,

                Tuesday12PM = listScheduler.Items[24].SubItems[1].Text,
                Tuesday1AM = listScheduler.Items[25].SubItems[1].Text,
                Tuesday2AM = listScheduler.Items[26].SubItems[1].Text,
                Tuesday3AM = listScheduler.Items[27].SubItems[1].Text,
                Tuesday4AM = listScheduler.Items[28].SubItems[1].Text,
                Tuesday5AM = listScheduler.Items[29].SubItems[1].Text,
                Tuesday6AM = listScheduler.Items[30].SubItems[1].Text,
                Tuesday7AM = listScheduler.Items[31].SubItems[1].Text,
                Tuesday8AM = listScheduler.Items[32].SubItems[1].Text,
                Tuesday9AM = listScheduler.Items[33].SubItems[1].Text,
                Tuesday10AM = listScheduler.Items[34].SubItems[1].Text,
                Tuesday11AM = listScheduler.Items[35].SubItems[1].Text,
                Tuesday12AM = listScheduler.Items[36].SubItems[1].Text,
                Tuesday1PM = listScheduler.Items[37].SubItems[1].Text,
                Tuesday2PM = listScheduler.Items[38].SubItems[1].Text,
                Tuesday3PM = listScheduler.Items[39].SubItems[1].Text,
                Tuesday4PM = listScheduler.Items[40].SubItems[1].Text,
                Tuesday5PM = listScheduler.Items[41].SubItems[1].Text,
                Tuesday6PM = listScheduler.Items[42].SubItems[1].Text,
                Tuesday7PM = listScheduler.Items[43].SubItems[1].Text,
                Tuesday8PM = listScheduler.Items[44].SubItems[1].Text,
                Tuesday9PM = listScheduler.Items[45].SubItems[1].Text,
                Tuesday10PM = listScheduler.Items[46].SubItems[1].Text,
                Tuesday11PM = listScheduler.Items[47].SubItems[1].Text,

                Wednesday12PM = listScheduler.Items[48].SubItems[1].Text,
                Wednesday1AM = listScheduler.Items[49].SubItems[1].Text,
                Wednesday2AM = listScheduler.Items[50].SubItems[1].Text,
                Wednesday3AM = listScheduler.Items[51].SubItems[1].Text,
                Wednesday4AM = listScheduler.Items[52].SubItems[1].Text,
                Wednesday5AM = listScheduler.Items[53].SubItems[1].Text,
                Wednesday6AM = listScheduler.Items[54].SubItems[1].Text,
                Wednesday7AM = listScheduler.Items[55].SubItems[1].Text,
                Wednesday8AM = listScheduler.Items[56].SubItems[1].Text,
                Wednesday9AM = listScheduler.Items[57].SubItems[1].Text,
                Wednesday10AM = listScheduler.Items[58].SubItems[1].Text,
                Wednesday11AM = listScheduler.Items[59].SubItems[1].Text,
                Wednesday12AM = listScheduler.Items[60].SubItems[1].Text,
                Wednesday1PM = listScheduler.Items[61].SubItems[1].Text,
                Wednesday2PM = listScheduler.Items[62].SubItems[1].Text,
                Wednesday3PM = listScheduler.Items[63].SubItems[1].Text,
                Wednesday4PM = listScheduler.Items[64].SubItems[1].Text,
                Wednesday5PM = listScheduler.Items[65].SubItems[1].Text,
                Wednesday6PM = listScheduler.Items[66].SubItems[1].Text,
                Wednesday7PM = listScheduler.Items[67].SubItems[1].Text,
                Wednesday8PM = listScheduler.Items[68].SubItems[1].Text,
                Wednesday9PM = listScheduler.Items[69].SubItems[1].Text,
                Wednesday10PM = listScheduler.Items[70].SubItems[1].Text,
                Wednesday11PM = listScheduler.Items[71].SubItems[1].Text,

                Thursday12PM = listScheduler.Items[72].SubItems[1].Text,
                Thursday1AM = listScheduler.Items[73].SubItems[1].Text,
                Thursday2AM = listScheduler.Items[74].SubItems[1].Text,
                Thursday3AM = listScheduler.Items[75].SubItems[1].Text,
                Thursday4AM = listScheduler.Items[76].SubItems[1].Text,
                Thursday5AM = listScheduler.Items[77].SubItems[1].Text,
                Thursday6AM = listScheduler.Items[78].SubItems[1].Text,
                Thursday7AM = listScheduler.Items[79].SubItems[1].Text,
                Thursday8AM = listScheduler.Items[80].SubItems[1].Text,
                Thursday9AM = listScheduler.Items[81].SubItems[1].Text,
                Thursday10AM = listScheduler.Items[82].SubItems[1].Text,
                Thursday11AM = listScheduler.Items[83].SubItems[1].Text,
                Thursday12AM = listScheduler.Items[84].SubItems[1].Text,
                Thursday1PM = listScheduler.Items[85].SubItems[1].Text,
                Thursday2PM = listScheduler.Items[86].SubItems[1].Text,
                Thursday3PM = listScheduler.Items[87].SubItems[1].Text,
                Thursday4PM = listScheduler.Items[88].SubItems[1].Text,
                Thursday5PM = listScheduler.Items[89].SubItems[1].Text,
                Thursday6PM = listScheduler.Items[90].SubItems[1].Text,
                Thursday7PM = listScheduler.Items[91].SubItems[1].Text,
                Thursday8PM = listScheduler.Items[92].SubItems[1].Text,
                Thursday9PM = listScheduler.Items[93].SubItems[1].Text,
                Thursday10PM = listScheduler.Items[94].SubItems[1].Text,
                Thursday11PM = listScheduler.Items[95].SubItems[1].Text,

                Friday12PM = listScheduler.Items[96].SubItems[1].Text,
                Friday1AM = listScheduler.Items[97].SubItems[1].Text,
                Friday2AM = listScheduler.Items[98].SubItems[1].Text,
                Friday3AM = listScheduler.Items[99].SubItems[1].Text,
                Friday4AM = listScheduler.Items[100].SubItems[1].Text,
                Friday5AM = listScheduler.Items[101].SubItems[1].Text,
                Friday6AM = listScheduler.Items[102].SubItems[1].Text,
                Friday7AM = listScheduler.Items[103].SubItems[1].Text,
                Friday8AM = listScheduler.Items[104].SubItems[1].Text,
                Friday9AM = listScheduler.Items[105].SubItems[1].Text,
                Friday10AM = listScheduler.Items[106].SubItems[1].Text,
                Friday11AM = listScheduler.Items[107].SubItems[1].Text,
                Friday12AM = listScheduler.Items[108].SubItems[1].Text,
                Friday1PM = listScheduler.Items[109].SubItems[1].Text,
                Friday2PM = listScheduler.Items[110].SubItems[1].Text,
                Friday3PM = listScheduler.Items[111].SubItems[1].Text,
                Friday4PM = listScheduler.Items[112].SubItems[1].Text,
                Friday5PM = listScheduler.Items[113].SubItems[1].Text,
                Friday6PM = listScheduler.Items[114].SubItems[1].Text,
                Friday7PM = listScheduler.Items[115].SubItems[1].Text,
                Friday8PM = listScheduler.Items[116].SubItems[1].Text,
                Friday9PM = listScheduler.Items[117].SubItems[1].Text,
                Friday10PM = listScheduler.Items[118].SubItems[1].Text,
                Friday11PM = listScheduler.Items[119].SubItems[1].Text,

                Saturday12PM = listScheduler.Items[120].SubItems[1].Text,
                Saturday1AM = listScheduler.Items[121].SubItems[1].Text,
                Saturday2AM = listScheduler.Items[122].SubItems[1].Text,
                Saturday3AM = listScheduler.Items[123].SubItems[1].Text,
                Saturday4AM = listScheduler.Items[124].SubItems[1].Text,
                Saturday5AM = listScheduler.Items[125].SubItems[1].Text,
                Saturday6AM = listScheduler.Items[126].SubItems[1].Text,
                Saturday7AM = listScheduler.Items[127].SubItems[1].Text,
                Saturday8AM = listScheduler.Items[128].SubItems[1].Text,
                Saturday9AM = listScheduler.Items[129].SubItems[1].Text,
                Saturday10AM = listScheduler.Items[130].SubItems[1].Text,
                Saturday11AM = listScheduler.Items[131].SubItems[1].Text,
                Saturday12AM = listScheduler.Items[132].SubItems[1].Text,
                Saturday1PM = listScheduler.Items[133].SubItems[1].Text,
                Saturday2PM = listScheduler.Items[134].SubItems[1].Text,
                Saturday3PM = listScheduler.Items[135].SubItems[1].Text,
                Saturday4PM = listScheduler.Items[136].SubItems[1].Text,
                Saturday5PM = listScheduler.Items[137].SubItems[1].Text,
                Saturday6PM = listScheduler.Items[138].SubItems[1].Text,
                Saturday7PM = listScheduler.Items[139].SubItems[1].Text,
                Saturday8PM = listScheduler.Items[140].SubItems[1].Text,
                Saturday9PM = listScheduler.Items[141].SubItems[1].Text,
                Saturday10PM = listScheduler.Items[142].SubItems[1].Text,
                Saturday11PM = listScheduler.Items[143].SubItems[1].Text,

                Sunday12PM = listScheduler.Items[144].SubItems[1].Text,
                Sunday1AM = listScheduler.Items[145].SubItems[1].Text,
                Sunday2AM = listScheduler.Items[146].SubItems[1].Text,
                Sunday3AM = listScheduler.Items[147].SubItems[1].Text,
                Sunday4AM = listScheduler.Items[148].SubItems[1].Text,
                Sunday5AM = listScheduler.Items[149].SubItems[1].Text,
                Sunday6AM = listScheduler.Items[150].SubItems[1].Text,
                Sunday7AM = listScheduler.Items[151].SubItems[1].Text,
                Sunday8AM = listScheduler.Items[152].SubItems[1].Text,
                Sunday9AM = listScheduler.Items[153].SubItems[1].Text,
                Sunday10AM = listScheduler.Items[154].SubItems[1].Text,
                Sunday11AM = listScheduler.Items[155].SubItems[1].Text,
                Sunday12AM = listScheduler.Items[156].SubItems[1].Text,
                Sunday1PM = listScheduler.Items[157].SubItems[1].Text,
                Sunday2PM = listScheduler.Items[158].SubItems[1].Text,
                Sunday3PM = listScheduler.Items[159].SubItems[1].Text,
                Sunday4PM = listScheduler.Items[160].SubItems[1].Text,
                Sunday5PM = listScheduler.Items[161].SubItems[1].Text,
                Sunday6PM = listScheduler.Items[162].SubItems[1].Text,
                Sunday7PM = listScheduler.Items[163].SubItems[1].Text,
                Sunday8PM = listScheduler.Items[164].SubItems[1].Text,
                Sunday9PM = listScheduler.Items[165].SubItems[1].Text,
                Sunday10PM = listScheduler.Items[166].SubItems[1].Text,
                Sunday11PM = listScheduler.Items[167].SubItems[1].Text,
            }
            ;

            ProgramSchedule.SerializeToXml(program, ProgramSchedule.filePath);
            ProgramSchedule.GetSchedule();
            this.Close();
        }
    }
}

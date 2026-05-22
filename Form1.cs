namespace probandoWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private int calculateDays(int year, int month)
        {
            return DateTime.DaysInMonth(year, month);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int countdown = 0;

            DateTimePicker from = dateTimePicker1;

            int fromDay = from.Value.Day;
            int fromMonth = from.Value.Month;
            int fromYear = from.Value.Year;

            DateTimePicker to = dateTimePicker2;

            int toDay = to.Value.Day;
            int toMonth = to.Value.Month;
            int toYear = to.Value.Year;

            int month = fromMonth;

            for (int i = fromYear; i <= toYear; i++)
            {

                for (int j = month; j <= 12; j++)
                {

                    // When the starting year and month is equal calculate the days in that month
                    if (fromYear == toYear && fromMonth == toMonth && i == toYear && j == toMonth)
                    {
                        for (int k = fromDay; k <= toDay; k++)
                        {
                            countdown++;
                        }
                    }

                    // Calculate in a interval of months in the same year the first month
                    if (fromYear == toYear && fromMonth != toMonth && i == toYear && j == fromMonth)
                    {
                        for (int k = fromDay; k <= calculateDays(i, j); k++)
                        {
                            countdown++;
                        }
                    }

                    // Calculate days when the program arrives to the desired month
                    if (fromYear == toYear && fromMonth != toMonth && i == toYear && j == toMonth)
                    {
                        for (int k = 1; k <= toDay; k++)
                        {
                            countdown++;
                        }

                        break;
                    }

                    // Calculate days that are between the two selected months
                    if (fromYear == toYear && fromMonth != toMonth && i == toYear && j != fromMonth && j != toMonth)
                    {
                        countdown += calculateDays(i, j);
                    }



                    // Calculates the first month in a interval of two differents years
                    if (fromYear != toYear && i == fromYear && j == fromMonth)
                    {
                        for (int k = fromDay; k <= calculateDays(i, j); k++)
                        {
                            countdown++;
                        }
                    }

                    // Calculate all months of the start year except the first one when the two years differ
                    if (fromYear != toYear && i == fromYear && j != fromMonth)
                    {
                        countdown += calculateDays(i, j);
                    }

                    // When the two years differ and the program is already in the objective year and in the objective month
                    if (fromYear != toYear && i == toYear && j == toMonth)
                    {
                        for (int k = 1; k <= toDay; k++)
                        {
                            countdown++;
                        }

                        break;
                    }

                    // When the program is in the objective year but not yet in the objective month calculate this
                    if (fromYear != toYear && i == toYear && j != toMonth)
                    {
                        countdown += calculateDays(i, j);
                    }

                    if (fromYear != toYear && i != toYear && i != fromYear)
                    {
                        countdown += calculateDays(i, j);
                    }

                }

                month = 1;
            }

            label4.Text = countdown.ToString() + ", Days";

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

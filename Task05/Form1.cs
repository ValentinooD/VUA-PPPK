using MongoDB.Bson;
using MongoDB.Driver;
using Task05.Models;

namespace Task05
{
    public partial class Form1 : Form
    {
        private IMongoClient client;
        private IMongoDatabase database;
        private const string COLLECTION_NAME = "people";

        private Person? selected;
        private IMongoCollection<Person> people;

        public Form1(IMongoClient client, IMongoDatabase database)
        {
            this.client = client;
            this.database = database;
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!IsFormValid())
            {
                return;
            }

            selected = new Person()
            {
                Name = tbName.Text,
                Surname = tbSurname.Text,
                Group = tbGroup.Text,
                Notes = tbNotes.Text
            };

            people.InsertOne(selected);

            LoadList();
        }

        private bool IsFormValid()
        {
            lbErrorGroup.Visible = false;
            lbErrorName.Visible = false;
            lbErrorNotes.Visible = false;
            lbErrorSurname.Visible = false;

            bool ok = true;
            if (string.IsNullOrEmpty(tbName.Text))
            {
                lbErrorName.Visible = true;
                ok &= false;
            }

            if (string.IsNullOrEmpty(tbSurname.Text))
            {
                lbErrorSurname.Visible = true;
                ok &= false;
            }

            if (string.IsNullOrEmpty(tbGroup.Text))
            {
                lbErrorGroup.Visible = true;
                ok &= false;
            }

            if (string.IsNullOrEmpty(tbNotes.Text))
            {
                lbErrorNotes.Visible = true;
                ok &= false;
            }

            return ok;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selected == null) return;

            people.DeleteOne(p => p.Equals(selected));

            selected = null;

            tbName.Text = "";
            tbSurname.Text = "";
            tbGroup.Text = "";
            tbNotes.Text = "";

            LoadList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selected == null) return;

            var updateFilter = Builders<Person>.Update.Set(p => p.Name, tbName.Text)
                                                      .Set(p => p.Surname, tbSurname.Text)
                                                      .Set(p => p.Group, tbGroup.Text)
                                                      .Set(p => p.Notes, tbNotes.Text);

            people.UpdateOne(p => p._id == selected._id, updateFilter);

            LoadList();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            lbErrorGroup.Visible = false;
            lbErrorName.Visible = false;
            lbErrorNotes.Visible = false;
            lbErrorSurname.Visible = false;

            LoadList();
        }

        private async void LoadList()
        {
            people = database.GetCollection<Person>(COLLECTION_NAME);

            var docs = await people.Find(_ => true).ToListAsync();

            lbPeople.Items.Clear();
            docs.ForEach(p =>
            {
                lbPeople.Items.Add(p);
            });
        }

        private void lbPeople_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbPeople.SelectedItem != null)
            {
                selected = lbPeople.SelectedItem as Person;

                tbName.Text = selected.Name;
                tbSurname.Text = selected.Surname;
                tbGroup.Text = selected.Group;
                tbNotes.Text = selected.Notes;
            }
        }
    }
}

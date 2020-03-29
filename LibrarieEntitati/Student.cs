namespace LibrarieEntitati
{
    public class Student
    {
        // date membre private
        string nume, prenume;
        int[] note;
        int id;

        // contructor implicit
        public Student()
        {
        }

        // constructor cu parametri
        public Student(string _nume, string _prenume)
        {
            nume = _nume;
            prenume = _prenume;
        }

        public Student(string date_fisier)
        {
            string[] date;
            date = date_fisier.Split(',');
            id = System.Convert.ToInt32(date[0]);
            prenume = date[1];
            nume = date[2];
            SetNote(date[3]);
        }

        public void SetNote(string sirNote)
        {
            string[] sir_note = sirNote.Split(' ');
            note = new int[sir_note.Length];
            int i = 0;
            foreach(var nota in sir_note)
            {
                int n = 0;
                bool Rez = System.Int32.TryParse(nota, out n);
                if (Rez == true)
                {
                    int nota_int = System.Int32.Parse(nota);
                    if (nota_int > 0 && nota_int <= 10)
                    {
                        note[i] = nota_int;
                        i++;
                    }
                }
            }
            System.Array.Resize(ref note, i);
        }

        public void SetNote(int[] _note)
        {
            note = new int[_note.Length];
            for(int i=0;  i< _note.Length; i++)
            {
                note[i] = _note[i];
            }
        }
        public string ConversieLaSir()
        {
            string sNote = "Nu exista (Nu ati apelat metoda **setNote**)";
            string nume_complet = nume;
            if (note != null)
            {
                sNote = string.Join(",", note);
            }
            if (string.IsNullOrEmpty(prenume) == false)
                nume_complet += " " + prenume;
            string s = string.Format("Studentul {0} are notele:.... {1}", nume_complet, sNote);

            return s;
        }

        public void NumarareNote(out int valSub5,out int valPeste5)
        {
            valSub5 = valPeste5 = 0;
            for(int i=0; i<note.Length; i++)
            {
                if (note[i] < 5)
                    valSub5++;
                else
                    valPeste5++;
            }
        }
    }
}

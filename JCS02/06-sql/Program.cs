using System.Data.SqlClient;
string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Marti\\Downloads\\db.mdf;Integrated Security=True;Connect Timeout=30";

using (SqlConnection connection = new SqlConnection(connectionString))
{
    
    connection.Open();
    // start a new transaction
    SqlTransaction transaction = connection.BeginTransaction();

    int affected = 0;

    try
    {
        // 01 return database to initial state
        SqlCommand removeAdded = new SqlCommand("DELETE FROM students WHERE OsCislo='R18264' OR OsCislo='R22001';", connection);
        // 02 sort by surname and return 6 unique names and surnames
        SqlCommand getSixUnique = new SqlCommand("SELECT DISTINCT * FROM students ORDER BY Prijmeni OFFSET 2 ROWS FETCH NEXT 6 ROWS ONLY;", connection);
        // 03 add student
        SqlCommand addStudent = new SqlCommand("INSERT INTO students (OsCislo, Jmeno, Prijmeni, UserName, Rocnik, OborKomb) VALUES (@id, @name, @surname, @username, @year, @field);", connection);
        // 04 delete all IT students
        SqlCommand deleteIt = new SqlCommand("DELETE FROM students WHERE OborKomb='IT';", connection);
        // 05 change username of student with OsCislo 'R21390' to 'holuma08'
        SqlCommand changeUsername = new SqlCommand("UPDATE students SET UserName='holuma08' WHERE OsCislo='R21390';", connection);
        // 06 get all grades of remaining students
        SqlCommand getGrades = new SqlCommand("SELECT CONCAT(students.Jmeno, ' ', students.Prijmeni) as CeleJmeno, students.OsCislo as OsCislo, exams.Subject AS Subject, exams.Grade AS Grade FROM students JOIN exams ON students.OsCislo = exams.StudentOsCislo ORDER BY students.Prijmeni, students.OsCislo;", connection);


        // 01
        removeAdded.Transaction = transaction;

        affected = removeAdded.ExecuteNonQuery();
        transaction.Commit();
        Console.WriteLine("Restored database, rows affected: " + affected + "\n");


        // 02
        Console.WriteLine("Six unique names and surnames:");

        using (SqlDataReader reader = getSixUnique.ExecuteReader())
        {
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader[i] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }


        // 03
        // add student
        addStudent.Parameters.Add(new SqlParameter("id", "R18264"));
        addStudent.Parameters.Add(new SqlParameter("name", "Alois"));
        addStudent.Parameters.Add(new SqlParameter("surname", "FRIDRICH"));
        addStudent.Parameters.Add(new SqlParameter("username", "frial01"));
        addStudent.Parameters.Add(new SqlParameter("year", 2));
        addStudent.Parameters.Add(new SqlParameter("field", "INF-PVS"));

        transaction = connection.BeginTransaction();
        addStudent.Transaction = transaction;

        affected = addStudent.ExecuteNonQuery();
        transaction.Commit();
        Console.WriteLine("Added student, rows affected: " + affected);

        // add another student
        addStudent.Parameters["id"].Value = "R22001";
        addStudent.Parameters["name"].Value = "Jana";
        addStudent.Parameters["surname"].Value = "NOVÁKOVÁ";
        addStudent.Parameters["username"].Value = "novja20";
        addStudent.Parameters["year"].Value = 1;
        addStudent.Parameters["field"].Value = "INF-PVS";

        transaction = connection.BeginTransaction();
        addStudent.Transaction = transaction;

        affected = addStudent.ExecuteNonQuery();
        transaction.Commit();
        Console.WriteLine("Added student, rows affected: " + affected);


        // 04
        transaction = connection.BeginTransaction();
        deleteIt.Transaction = transaction;

        affected = deleteIt.ExecuteNonQuery();
        transaction.Commit();
        Console.WriteLine("Removed IT students, rows affected: " + affected);


        // 05
        affected = changeUsername.ExecuteNonQuery();
        Console.WriteLine("Changed username of R21390, rows affected: " + affected);
        Console.WriteLine();

        
        // 06
        Console.WriteLine("All grades of remaining students:");

        using (SqlDataReader reader = getGrades.ExecuteReader())
        {
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader[i] + " ");
                }
                Console.WriteLine();
            }
        }
    }
    catch (SqlException sqlEx)
    {
        Console.WriteLine("SQL error: " + sqlEx.Message);
        Console.WriteLine("Rolling back transaction...");

        try
        {
            transaction.Rollback();
        }
        catch (Exception rollbackFailed)
        {
            Console.WriteLine("Rollback failed: " + rollbackFailed.Message);
        }
    }
}
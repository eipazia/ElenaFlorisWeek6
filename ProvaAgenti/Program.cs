// See https://aka.ms/new-console-template for more information

//1.Quali sono i paradigmi della programmazione ad oggetti? 
//    a,e,g
//2.Indicare la / le risposte corrette
//    b) Un metodo di tipo abstract non è dotato di implementazione
//    c) La classe che eredita un metodo di tipo abstract può non implementare il funzionamento 
//3.Data una classe padre contenente il metodo “public virtual void Stampa()”, quale / i metodi può
//contenere la classe figlia? 
//c) public override void Stampa()
using ProvaAgenti;

Console.WriteLine("Hello, World!");
Console.WriteLine("Agenti di Polizia");
//RepositoryMOCK repositoryAgenti = new RepositoryMOCK();
RepositoryDbADO repositoryAgenti = new RepositoryDbADO();
bool continua = true;
while (continua)
{
    Console.WriteLine("--------------------------------Menu----------------------------");
    Console.WriteLine("1. Mostrare tutti gli agenti di polizia ");
    Console.WriteLine("2. Scelta un’area geografica, mostrare gli agenti assegnati a quell’area");
    Console.WriteLine("3. Scelti gli anni di servizio, mostrare gli agenti con anni di servizio maggiori o uguali rispetto all’input");
    Console.WriteLine("4. Inserire un nuovo agente solo se non è già presente nel database ");
    Console.WriteLine("0. Exit");


    int scelta;
    do
    {
        Console.WriteLine("Seleziona una tra le possibili opzioni");
    } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 4));

    switch (scelta)
    {
        case 1:
            MostraAgenti();
            break;
        case 2:
            AgentiPerAreaGeografica();
            break;
        case 3:
            AgentiAnniServizio();
            break;
        case 4:
            InserisciAgente();
            break;
        case 0:
            continua = false;
            break;
    }
}

void InserisciAgente()
{
    Console.WriteLine("Quale agente vuoi inserire?");
    Console.WriteLine("Inserisci nome");
    string nome = Console.ReadLine();
    Console.WriteLine("Inserisci cognome");
    string cognome = Console.ReadLine();
    Console.WriteLine("Inserisci CF");
    string cf = Console.ReadLine();
    
    Console.WriteLine("Inserisci area geografica");
    string areag = Console.ReadLine();
    Console.WriteLine("Inserisci anno inizio attività");
    int annoinizioattivita = int.Parse(Console.ReadLine());
    while (repositoryAgenti.GetByCodiceFiscale(cf) == null) ;
    {
        Console.WriteLine("Formato errato e/o codice isbn già presente. Riprova");
    }
    var agente = new Agente(nome,cognome,cf, areag,annoinizioattivita);
    bool esito = repositoryAgenti.Aggiungi(agente);
    if (esito)
    {
        Console.WriteLine("Aggiunto correttamente");
    }
    else
    {
        Console.WriteLine("Errore. Non è stato possibile aggiungere!");
    }
   
}

void AgentiAnniServizio()
{
    Console.WriteLine("Inserisci anno servizio:");
    int annoinizio = int.Parse(Console.ReadLine());
    var agenti = repositoryAgenti.GetAll();
   
    Console.WriteLine("Agenti per Anni servizio");
        foreach (var item in agenti)
        {
            //if (item.AnnoInizioAttivita == annoinizio)
            //{
            //       Console.WriteLine(item);
            //}
        if (item.AnnoInizioAttivita >= annoinizio)
        {
            Console.WriteLine(item);
        }

    }
}


void AgentiPerAreaGeografica()
{
    Console.WriteLine("Inserisci area geografica:");
    string areaDaRicercare = Console.ReadLine();
    var a1 = repositoryAgenti.GetByArea(areaDaRicercare);
    List<Agente> agenti = new List<Agente>();
    agenti.Add(a1);
    Console.WriteLine("Agenti per Area");
    foreach (var item in agenti)
    {
        Console.WriteLine(item);
    }
}

void MostraAgenti()
{
   Console.WriteLine("Tutti gli Agenti");
    var agenti = repositoryAgenti.GetAll();
    List<Agente> listaCompleta = new List<Agente>();
    listaCompleta.AddRange(agenti);
   

    foreach (var item in listaCompleta)
    {
        Console.WriteLine(item.ToString());
    }
}
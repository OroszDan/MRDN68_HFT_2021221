let directors = [];
let connection = null;
let directorIdToUpdate = -1;
let DirectorNamesOfMoviesShownBefore2004InCinemaCityCinemas = [];
let PGCategoryMovieNamesShownAfter12_30 = [];
let DateTimesOfMoviesShownInBudapestWhoseDirectorsBornBefore1962 = [];

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:65512/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("DirectorCreated", (user, message) => {
        getdata();
    });

    connection.on("DirectorDeleted", (user, message) => {
        getdata();
    });

    connection.on("DirectorUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:65512/director')
        .then(x => x.json())
        .then(y => {
            directors = y;
            console.log(directors);
            display();
        });


    await fetch('http://localhost:65512/showtimestat/getquery3')
        .then(x => x.json())
        .then(y => {
            DirectorNamesOfMoviesShownBefore2004InCinemaCityCinemas = y;
            console.log(DirectorNamesOfMoviesShownBefore2004InCinemaCityCinemas);
            //displayqueries();
        });

    await fetch('http://localhost:65512/showtimestat/getquery4')
        .then(x => x.json())
        .then(y => {
            PGCategoryMovieNamesShownAfter12_30 = y;
            console.log(PGCategoryMovieNamesShownAfter12_30);
            //displayqueries();

        });

    await fetch('http://localhost:65512/showtimestat/getquery5')
        .then(x => x.json())
        .then(y => {
            DateTimesOfMoviesShownInBudapestWhoseDirectorsBornBefore1962 = y;
            console.log(DateTimesOfMoviesShownInBudapestWhoseDirectorsBornBefore1962);
            displayqueries();

        });
    

}


function display() {
    document.getElementById('resultarea').innerHTML = "";
    directors.forEach(t => {
        console.log(t.name);
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>"
            + t.birthYear + "</td><td>" +
            `<button type="button" onclick="remove(${t.id})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.id})">Update</button>` + "</td></tr>";
    });

}

function displayqueries() {
    lefutottmar = false;
    if (!lefutottmar) {

        document.getElementById('queryresultarea').innerHTML = "";
      

        document.getElementById('queryresultarea').innerHTML +=
            "<tr><th>Director Names Of Movies Shown Before 2004 In Cinema City Cinemas</th></tr>";


        DirectorNamesOfMoviesShownBefore2004InCinemaCityCinemas.forEach(x => {

            document.getElementById('queryresultarea').innerHTML +=
                "<tr><td>" + x + "</td></tr>";

        });


        document.getElementById('queryresultarea').innerHTML +=
            "<tr><th>PG Category Movie Names Shown After 12_30</th></tr>";

        
        PGCategoryMovieNamesShownAfter12_30.forEach(x => {

            document.getElementById('queryresultarea').innerHTML +=
                "<tr><td>" + x + "</td></tr>";
            
        });

        document.getElementById('queryresultarea').innerHTML +=
            "<tr><th> DateTimes Of Movies Shown In Budapest Whose Directors Were Born Before 1962</th></tr>";
       
       
        DateTimesOfMoviesShownInBudapestWhoseDirectorsBornBefore1962.forEach(x => {
           
            document.getElementById('queryresultarea').innerHTML +=
                "<tr><td>" + x + "</td></tr>";
            
        });

       

    }
    lefutottmar = true;
}

function create()
{
    let name = document.getElementById('directorname').value;
    let year = document.getElementById('directoryear').value;
    fetch('http://localhost:65512/director', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: name, birthYear: year })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
   

}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('directornametoupdate').value;
    let year = document.getElementById('directoryeartoupdate').value;
    fetch('http://localhost:65512/director', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: name, birthYear: year, id: directorIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });


}

function remove(id) {
    fetch('http://localhost:65512/director/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function showupdate(id) {
    document.getElementById('directornametoupdate').value = directors.find(t => t['id'] == id)['name'];
    document.getElementById('directoryeartoupdate').value = directors.find(t => t['id'] == id)['birthYear'];
    document.getElementById('updateformdiv').style.display = 'flex';
    directorIdToUpdate = id;
}


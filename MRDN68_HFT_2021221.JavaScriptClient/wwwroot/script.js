let director = [];
let connection = null;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:65512/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("MovieCreated", (user, message) => {
        getdata();
    });

    connection.on("MovieDeleted", (user, message) => {
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
            director = y;
            console.log(director);
            display();
        });
}


function display() {
    document.getElementById('resultarea').innerHTML = "";
    director.forEach(t => {
        console.log(t.name);
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>"
            + t.birthYear + "</td><td>" +
                `<button type="button" onclick="remove(${t.id})">Delete</button>` + "</td></tr>";
    });

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


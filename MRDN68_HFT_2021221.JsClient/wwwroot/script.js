let director = [];

getdata();

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
    director.forEach(t => {
        console.log(t.name);
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>"
        + t.birthYear + "</td></tr>";
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


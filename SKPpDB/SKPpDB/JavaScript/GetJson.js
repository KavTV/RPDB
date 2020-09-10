

async function kagetest() {

    const response = await fetch("https://localhost:44369/projects");
    console.log(response);
    const data = await response.json();
    console.log(data);

    console.log("DET FUCING VIRKER");
}

kagetest();
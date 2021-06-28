const buttons = document.querySelectorAll(".card a");
const selectCampus = document.getElementById("campus");
const inputIdCarrera = document.getElementById("IdCarrera");
buttons.forEach(el => {
    el.addEventListener("click", e => {

        inputIdCarrera.value = el.getAttribute("data-id");

        window.scrollTo({ left: 0, top: document.body.scrollHeight, behavior: "smooth" });

        fetch(`/Solicitante/getCampus?IdCarrera=${inputIdCarrera.value}`)
            .then(function (result) {

                if (result.ok) {
                    return result.json();
                }
            }).then(function (data) {

                let option;
                selectCampus.innerHTML = "";
                selectCampus.innerHTML += "<option>--Seleccione el campus--</option>";
                data.forEach(el => {

                    option = document.createElement("option");
                    option.appendChild(document.createTextNode(el.Nombre));
                    option.value = el.Id;
                    selectCampus.appendChild(option);
                });
            })

    });
});







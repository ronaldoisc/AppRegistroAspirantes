const selectPaises = document.getElementById('paises');
const codigoPostal = document.getElementById('codigoPostal');
const selectLocalidades = document.getElementById('localidades');


$('#paises').select2({
    placeholder: 'Busca un país',
    theme: 'bootstrap'
});

fetch('/Locacion/Paises').then(response => response.json()).then(data => {
    data.forEach(e => {

        document.getElementById('paises').innerHTML += `<option value="${e.Id}">${e.Nombre}</option>`;
    })
});

codigoPostal.addEventListener('keyup', () => {
    selectLocalidades.innerHTML = '<option value="">--Seleccione su localidad--</option>';
    fetch(`/locacion/localidades?codigoPostal=${codigoPostal.value}&pais=${selectPaises.value}`).then(response => response.json()).then(data => {
        data.forEach(e => {
            selectLocalidades.innerHTML += `<option value="${e.Id}">${e.Nombre}</option>`;
        })

    });
})
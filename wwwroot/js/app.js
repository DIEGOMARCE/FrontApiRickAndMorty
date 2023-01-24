document.addEventListener("DOMContentLoaded", () => {
    const getCharacters = async () => {
        const data = await axios.get('/apiPersonajes');
        return data;
    }

    const firstSeenIn = async (episodeId) => {
        const getInfo = await axios.get(`/apiEpisodios`);
        return getInfo;
    }

    const renderData = async () => {
        const characters = await getCharacters();
        const { results } = characters.data;
        results.map(async (character) => {
            const firstEpisode = await firstSeenIn(character.episode[0].split('/')[5]);
            character.firstEpisode = firstEpisode.data.name;
        })
        return await characters;
    }

    renderData().then(({ data }) => {
        const { results } = data;
        let infoCharacters = "";
        results.map((character) => {
            const { name, image, status, species, location } = character;

            const firstEpisodeId = character.episode[0].split('/')[5];
            firstSeenIn(firstEpisodeId).then((response) => {
                const firstEpisode = response.data.name;

            })

            infoCharacters += `
            <div class="card mb-3 me-4 mainWrapper" style="max-width: 650px;">
              <div class="row g-0">
                <div class="col-md-4">
                  <img src="${image}" class="img-fluid rounded-start" alt="...">
                </div>
                <div class="col-md-8">
                  <div class="card-body">
                    <h5 class="card-title">${name}</h5>
                    <span class="status"><span class="status__icon ${status === 'Alive' ? 'alive' : status === 'Dead' ? 'dead' : 'unknown'}"></span> ${status} - ${species}</span>

                    <p class="mt-2 mb-0">Last known location:</p>
                    <span>${location.name}</span>

                    <p class="mt-2 mb-0">First seen in::</p>
                    <span>${location.name}</span>

                  </div>
                </div>
              </div>
            </div>`;
        })

        document.getElementById('containerCharacters').innerHTML = infoCharacters;

    })

});


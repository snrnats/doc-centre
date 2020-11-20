# Redoc

<div id="redoc"></div>
<script src="https://cdn.jsdelivr.net/npm/redoc/bundles/redoc.standalone.js"> </script> 
<script>
    Redoc.init('https://raw.githubusercontent.com/andywalton7/ReDocTest/master/swagger.json', {
        hideDownloadButton: true,
        requiredPropsFirst: 1,
        expandResponses: "200",
        theme: {
        colors: {
            tonalOffset: '0',
            primary: {
            main: '#494B52'
            },
            success: {
            main: '#54b92b'
            },
            http: {
            get: '#FF055E',
            post: '#FF055E',
            put: '#FF055E',
            options: '#d3ca12',
            patch: '#e09d43',
            delete: '#FF055E',
            basic: '#999',
            link: '##FF055E',
            head: '##FF055E',
            },
        },
        typography: {
            fontSize: '14px',
            fontFamily: 'Circular Pro Book, sans-serif',
            headings: {
            fontFamily: 'Circular Pro Black, sans-serif',
            },
        },
        menu: {
            backgroundColor: '#fff',
            textColor: '#404040',
        },
        logo: {
            maxWidth: '180px',
        },
        rightPanel: {
            textColor: '#f7f7f7',
        }
        }
    }, document.getElementById('redoc'))
</script>

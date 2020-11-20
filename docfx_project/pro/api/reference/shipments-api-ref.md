<style type="text/css">
    .sideaffix {
        display: none;
    }

    .subnav {
        display: none !important;
    }

    .page-stats {
        display: none !important;
    }

    .container.body-content {
      width: 100%;
    }

    .docs-body {
      width: 100%;
      padding-left: 0;
      padding-right: 0;
    }

    .article {
      margin-top: 0px;
      margin-bottom: 0px;
    }

    header {
      position: relative;
    }

    .article img {
      border: 0 none;
    }

    body {
      background-color: #ffffff;
    }

</style>
<div id="redoc"></div>
<script src="https://cdn.jsdelivr.net/npm/redoc/bundles/redoc.standalone.js"></script>
<script>
    Redoc.init('/pro/api/swagger.json', {
        hideHostname: true,
        hideDownloadButton: true,
        requiredPropsFirst: 1,
        expandResponses: "200",
        expandSingleSchemaField: true,
        menuToggle: true,
        scrollYOffset: 25,
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
          backgroundColor: '#3C3C3C'
        },
        spacing: {
          sectionVertical: ({ spacing }) => spacing.unit * 2
        }
      }
    }, document.getElementById('redoc'))
</script>

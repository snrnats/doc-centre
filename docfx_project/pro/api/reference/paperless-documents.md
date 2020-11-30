---
uid: paperless-documents-api-reference
title: Paperless Documents API Reference
---
<link href="/styles/api-reference.css" rel="stylesheet">
<div id="redoc"></div>
<script src="/styles/redoc.standalone.js"></script>
<script type="text/javascript" defer>
    Redoc.init('/pro/api/reference/definitions/swagger-paperless-documents.yaml', {
        hideHostname: true,
        hideDownloadButton: false,
        requiredPropsFirst: 1,
        expandResponses: "200,201",
        expandSingleSchemaField: true,
        menuToggle: true,
        scrollYOffset: 25,
        sortPropsAlphabetically: true,
        pathInMiddlePanel: true,
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
              get: '#1c880b',
              post: '#f88f00',
              put: '#2196f3',
              options: '#d3ca12',
              patch: '#e09d43',
              delete: '#ce283c',
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


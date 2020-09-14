```json
{
    "custom_reference": "0af07451-cf80-43cb-af24-acdfdbd41a14inc",
    "required_delivery_date": {
        "start": "2019-04-27T07:00:00+01:00",
        "end": "2019-04-28T12:00:00+01:00"
    },
    "required_shipping_date": {
        "start": "2019-04-26T00:00:00+01:00",
        "end": "2019-04-26T23:59:59+01:00"
    },
    "tags": [
        "b&w",
        "T2"
    ],
    "order_date": "2019-04-05T09:34:55+01:00",
    "metadata": [
        {
            "key": "warehouse_id",
            "value": "WHF-0098762345D",
            "type": "string"
        },
        {
            "key": "refundable",
            "value": "false",
            "type": "boolean"
        }
    ],
    "customs_documentation": {
        "designated_person_responsible": "John McBride",
        "importers_vat_number": "0234555",
        "category_type": "gift",
        "shippers_customs_reference": "CREF0001",
        "importers_tax_code": "TC001",
        "importers_telephone": "+441772611444",
        "importers_fax": null,
        "importers_email": "jmcb@tilda.net",
        "cn23_comments": "Some comments here",
        "attached_invoice_references": [
            "63bc2ad5-dbff-4d30-a9b2-8081607d9921"
        ],
        "attached_certificate_references": [
            "bbc0eaa5-1a1d-4b56-b33a-a360680c1270"
        ],
        "attached_licence_references": [
            "0e5084d6-6509-4ff3-9771-66e63f452eb9"
        ],
        "category_type_explanation": "Free text",
        "declaration_date": "2019-04-26T14:57:54+01:00",
        "reason_for_export": "sale",
        "shipping_terms": "fca",
        "shippers_vat_number": "98798273434",
        "receivers_tax_code": "TC8793847",
        "receivers_vat_number": "9879879878675",
        "invoice_date": "2019-04-26T15:01:45+01:00"
    },
    "direction": "outbound",
    "shipment_type": "on_demand",
    "contents": [
        {
            "custom_reference": "b9fa91b0-0dd0-4dd5-986f-363fa8cb2386",
            "package_size_reference": null,
            "weight": {
                "value": 2.40,
                "unit": "Kg"
            },
            "dimensions": {
                "unit": "Cm",
                "width": 15.0,
                "height": 15.5,
                "length": 20.0
            },
            "description": "Jeans",
            "value": {
                "amount": 8.99,
                "currency": "GBP"
            },
            "sku": "SKU09876",
            "model": "MOD-009",
            "country_of_origin": "PO",
            "harmonisation_code": "09.02.10",
            "quantity": 2,
            "unit": "Box",
            "dangerous_goods": {
                "hazard_classes": [
                    { "code": "2.1" }
                ],
                "packing_group": "iii",
                "id_number": "UN2202",
                "proper_shipping_name": "Hydrogen selenide, anhydrous",
                "technical_name": null,
                "physical_form": "gas",
                "radioactivity": "surface_reading",
                "accessibility": "accessible",
                "custom_label_text": null
            },
            "metadata": [
                {
                    "key": "Category",
                    "value": "Menswear",
                    "type": "string"
                }
            ],
            "label_properties": null,
            "Contents": null
        }
    ],
    "addresses": [
        {
            "address_type": "origin",
            "shipping_location_reference": "SLOC001"
        },
        {
            "address_type": "destination",
            "shipping_location_reference": null,
            "custom_reference": "21bbd58a-6dec-4097-9106-17501ddca38d",
            "contact": {
                "reference": "co_9953035290535460865000098664453",
                "title": "Mr",
                "first_name": "Steve",
                "last_name": "Kingston",
                "middle_name": null,
                "position": null,
                "contact_details": {
                    "landline": null,
                    "mobile": "+447495747987",
                    "email": "steve@kingston.com"
                }
            },
            "company_name": null,
            "property_number": "8",
            "property_name": null,
            "address_line_1": "Norbert Road",
            "address_line_2": "Bertwistle",
            "address_line_3": null,
            "locality": "Preston",
            "region": "Lancashire",
            "postal_code": "PR4 5LE",
            "country_iso_code": "GB",
            "lat_long": null
        }
    ],
    "label_properties": [
        {
            "key": "chute",
            "value": "9D"
        }
    ],
    "source": "WMS",
    "tenant": "TENANT_001",
    "channel": "CHAN_003"
}
```
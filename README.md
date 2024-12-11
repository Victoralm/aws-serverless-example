# AWS Serverless Example

A simple example of a serverless AWS Api.

The main goal is showcase an Api that does some Web scraping and return its result.

Target URL: https://pt.exchange-rates.org/converter/USD/BRL/1

Endpoints on AWS:

-   [https://sycmft88j9.execute-api.sa-east-1.amazonaws.com/Prod/](https://sycmft88j9.execute-api.sa-east-1.amazonaws.com/Prod/)
    -   Using the simple example provided by the template
-   [https://sycmft88j9.execute-api.sa-east-1.amazonaws.com/Prod/teste](https://sycmft88j9.execute-api.sa-east-1.amazonaws.com/Prod/teste)
    -   Using a Repository pattern
    -   Added a simple Post example, with model state validation

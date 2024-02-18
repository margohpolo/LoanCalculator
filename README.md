# LoanCalculator

A .NET-Angular implementation of a LoanCalculator, with an EMI (Equal Monthly Installation) approach to calculating the Loan Repayment Schedule.

<b>Objective:</b> The Objective of this project was to do a quick, high-level refresher on .NET+Angular, with a secondary agenda of giving [.NET Aspire](https://learn.microsoft.com/en-us/dotnet/aspire/get-started/aspire-overview) a try.

<details>
<summary><b>Specs & Design Scalability</b></summary>

<details>
<summary><em>Main Feature</em></summary>
The Angular FE will receive user input (with validations) for the loan details, and the API does the calculation with the Repayment Schedule as the API call result.

<b>Banker's Rounding</b> is applied at the end of every calculation. Naturally, this would depend on the actual business requirements. One good read on this topic can be found [here](https://shopify.engineering/eight-tips-for-hanging-pennies).
</details>

<details>
<summary><em>Other Technical Details</em></summary>

- Strong Typing: Money and PercentageRates are custom ValueObjects.

- Unit Testing was implemented on the ValueObjects and the Repayment Schedule.

- A single API Endpoint was implemented, as opposed to the MVC Controllers approach, to keep the implementation clean for serving the needs of the current solution. (Further Readings: [Choose between controller-based APIs and minimal APIs](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/apis?view=aspnetcore-8.0)  |  [FastEndpoints](https://fast-endpoints.com/))

- [Documentation Comments](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/) were added to this project, for better collaboration between team members.

- When exploring Aspire, it was found that the default Redis caching configuring worked with Blazor, but there was no default implementation for Angular/React at the moment. The default .NET Weather API implementation in both Blazor & Angular were retained to demonstrate this.
</details>

<details>
<summary><em>Designing to Scale</em></summary>

Even though the Calculation could have been hard-coded in the FE, this implementation approach can better scale in terms of features, for example:
- <b>Different Loan Calculation Approaches</b>
This can be implemented by adjusting the API, and e.g. by adding a Radio selection or Dropdown to the FE.
- <b>Configurable Range of Allowed Interest Rates</b>
This can be implemented via 
(i) storing this configurable range in the DB;
(ii) An API call to retrieve this range;
(iii) Have a sliding scale + Textbox on the FE for the interest rate.
</details>


</details>


<br />

<details>
<summary><b>Dependencies</b></summary>
<b>Angular</b>

- Angular >= 17.1

- NPM >= 10.4

- Node >=20.11

<br />
<b>.NET</b>

- .NET >= 8.0.200-preview.23624.5

- Visual Studio (Community) >= 17.9.0 Preview 4 (Aspire is still in Preview as of time of writing)


<b>Docker</b>
</details>

### 



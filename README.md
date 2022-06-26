# Onventis.Test


## How to verify

1. Download project from GitHub

2. Open Solution in IDE

3. Run migrations:

	3.1 Optional: Run `dotnet tool install --global dotnet-ef`

	3.2 Run `dotnet ef database update -p Onventis.Test.Webhook.Data -s Onventis.Test.Webhook.Compose`
	
4. Set Several Startup projects:

	4.1 Onventis.Test.API

	4.2 Onventis.Test.Webhook.Compose

	4.3 Onventis.Test.Webhook.Notifier
	
5. Start projects

6. Perform post http reguest to Onventis.Test.API (e.g. using Postman): 

	6.1 URL: https://localhost:{port}/invoice/approve/19

	6.2 Method: POST
	
7. Open Logs for Onventis.Test.Webhook.Notifier: `docker logs Onventis.Test.Webhook.Notifier`


## Known issues:

1. Real HTTP call to URLs subscribed to webhooks are not implemented. Info is just logged to console
2. Sometime some events are not handled without any error in log. STRs and root causes are not found

# IFSP API - Name Analysis Service


![CI/CD](https://github.com/jcmdsbr/cicd-sample/actions/workflows/pipeline.yaml/badge.svg)

An API service that provides cultural and linguistic analysis of names using OpenAI's GPT model. This project is built with .NET 9.0 and follows cloud-native principles with Docker containerization.

## 🚀 Features

- RESTful API endpoint for name analysis
- Cultural and linguistic meaning analysis across multiple cultures
- Docker containerization support
- CI/CD pipeline with GitHub Actions
- Markdown to plain text conversion for responses

## 📋 Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/products/docker-desktop)
- OpenAI API Key

## 🛠️ Configuration

### Environment Variables

The application uses the following configuration parameters that can be set in `appsettings.json` or through environment variables:

```json
{
  "OpenAi": {
    "BaseUrl": "YOUR_OPENAI_BASE_URL",
    "ApiKey": "YOUR_OPENAI_API_KEY"
  }
}
```

### Docker Environment Variables

When running with Docker, configure the following environment variables in the container:

- `OpenAi__BaseUrl`: OpenAI API base URL
- `OpenAi__ApiKey`: Your OpenAI API key
- `ASPNETCORE_ENVIRONMENT`: Application environment (Development, Production, etc.)

## 🚀 Running the Application

### Local Development

1. Clone the repository:
   ```bash
   git clone https://github.com/jcmdsbr/cicd-sample.git
   cd Ifsp.Api
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Run the application:
   ```bash
   dotnet run --project src/Ifsp.Api/Ifsp.Api.csproj
   ```

### Using Docker

1. Build the container:
   ```bash
   docker build -t ifsp.api ./src
   ```

2. Run the container:
   ```bash
   docker run -d -p 8080:80 \
     -e OpenAi__BaseUrl=YOUR_OPENAI_BASE_URL \
     -e OpenAi__ApiKey=YOUR_OPENAI_API_KEY \
     --name ifsp.api ifsp.api
   ```

### Using Docker Compose

```bash
docker-compose -f src/compose.yaml up -d
```

## 🔌 API Endpoints

### Get Name Analysis

```http
GET /v1/whats-meaning-name/{name}
```

#### Parameters

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `name`    | `string` | **Required**. Name to analyze |

#### Response

The endpoint returns a detailed analysis of the name's meaning across different cultures:
- Indigenous cultures (focusing on Latin America)
- European cultures
- Asian cultures
- American cultures (North and South America)

## 🛠️ Built With

- [.NET 9.0](https://dotnet.microsoft.com/) - Framework
- [OpenAI API](https://openai.com/) - AI service for name analysis
- [Markdig](https://github.com/xoofx/markdig) - Markdown processing
- [Docker](https://www.docker.com/) - Containerization
- [GitHub Actions](https://github.com/features/actions) - CI/CD

## 👥 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## ✨ Author

* **Jean Carlos M. da Silva** - [GitHub](https://github.com/jcmdsbr)
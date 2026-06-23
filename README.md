# Intelligent Support Ticket Router 🤖

An AI-powered support ticket routing API built with C# and .NET.

This project explores practical AI integration in backend systems by using a local Large Language Model (LLM) to analyze customer support messages and assist with ticket classification and routing.

## 🚀 Overview

The application receives customer support tickets and uses an AI orchestration layer to:

- Analyze customer messages
- Understand ticket context
- Identify possible categories and priorities
- Assist support workflows

The AI runs locally using Ollama, allowing development without external API costs while keeping the data private.

## 🛠️ Tech Stack

- C#
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- MySQL
- Semantic Kernel
- Ollama (Local LLM)
- Swagger

## ✨ Features

- REST API for ticket processing
- AI-powered ticket analysis
- Local LLM execution
- Backend orchestration layer
- Database persistence with Entity Framework Core
- Swagger API documentation
- Dependency Injection
- Clean separation of responsibilities

## 📂 Project Structure

src
├── IntelligentTicketRouter.Api
├── IntelligentTicketRouter.Application
├── IntelligentTicketRouter.Domain
└── IntelligentTicketRouter.Infrastructure

## ▶️ Running Locally

### Requirements

- .NET 8 SDK
- MySQL
- Ollama

### Install and run Ollama

Install Ollama:

<https://ollama.com>

Start the Ollama service:

ollama serve
ollama pull llama3.1
ollama run llama3.1

### AI Integration

The application uses Semantic Kernel to communicate with the local LLM.

The AI layer is responsible for:

Understanding ticket messages
Extracting relevant information
Generating support recommendations

The LLM can be replaced in the future with hosted providers such as OpenAI or Azure OpenAI with minimal changes.

### Future Improvements

- Add ticket persistence and history
- Add authentication and authorization
- Add background processing with workers
- Add RabbitMQ event-driven communication
- Add RAG with embeddings and vector databases
- Improve AI responses with structured outputs
- Add automated tests

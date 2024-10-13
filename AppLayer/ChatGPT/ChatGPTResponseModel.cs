using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.ChatGPT; 

public class ChatGptResponseModel {
    public string Id { get; set; }
    public string Object { get; set; }
    public long? Created { get; set; }  // Nullable in case of an error
    public string Model { get; set; }
    public List<Choice> Choices { get; set; }
    public Usage Usage { get; set; }
    public object SystemFingerprint { get; set; }
    public ErrorResponse Error { get; set; }  // Handle error responses
}

public class Choice {
    public int Index { get; set; }
    public Message Message { get; set; }
    public object Logprobs { get; set; }
    public string FinishReason { get; set; }
}

public class Message {
    public string Role { get; set; }
    public string Content { get; set; }
    public object Refusal { get; set; }
}

public class Usage {
    public int PromptTokens { get; set; }
    public int CompletionTokens { get; set; }
    public int TotalTokens { get; set; }
    public PromptTokensDetails PromptTokensDetails { get; set; }
    public CompletionTokensDetails CompletionTokensDetails { get; set; }
}

public class PromptTokensDetails {
    public int CachedTokens { get; set; }
}

public class CompletionTokensDetails {
    public int ReasoningTokens { get; set; }
}

// Error response model
public class ErrorResponse {
    public string Message { get; set; }  // The error message (e.g., "Invalid API key provided")
    public string Type { get; set; }     // Type of error (e.g., "invalid_request_error")
    public string Param { get; set; }    // Parameter involved in the error, if any
    public string Code { get; set; }     // Error code (e.g., "invalid_api_key")
}
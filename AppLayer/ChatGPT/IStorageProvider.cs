using AppLayer.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.ChatGPT;
[ApplicationPort]

public interface IStorageProvider {
    public Task<ChatGptResponseModel> SendPrompt(string prompt);
}
using Microsoft.ML;
using System;
using System.Collections.Generic;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms.Text;
using System.Text;
using System.Linq

namespace HelloWorld
{
  
  class Program
  {
    static void Main(string[] args)
    {
      var context = new MLContext();
      var emptydata = new List<TextData> ();
      var data = context.Data.LoadFromEnumerable(emptydata);
      var tokenization = context.Transforms.Text.TokenIntoWords("Tokens", "Text", separators : new[] {' ', '!', '.'});
      var tokenmodel = tokenization.Fit(data);
      var engine = context.Model.CreatePredictionEngine<TextData, TextTokens>(tokenmodel);
      var tokens = engine.Predict(new TextData {Text = "ML. Net is good for Machine Learning! ML is also good for testing."});
      PrintTokens(tokens, 5);
      Console.ReadLine();
      
      
      var context2 = new MLContext();
      var emptydata2 = new List<TextData> ();
      var data2 = context.Data.LoadFromEnumerable(emptydata2);
      var tokenization2 = context.Transforms.Text.TokenIntoWords("Tokens", "Text", separators : new[] {' ', '!', '.'}).
      Append(context.Transforms.Text.RemoveDefaultStopWords("Tokens", "Tokens", 
      Microsoft.ML.Transforms.Text.StopWordsRemovingEstimator.Language.English));
      
      var tokenmodel2 = tokenization.Fit(data2);
      var engine2 = context.Model.CreatePredictionEngine<TextData, TextTokens>(tokenmodel2);
      var text = engine2.Predict(new TextData {Text = "This is a test sentence, and it is a good one"});
      PrintTokens2(text);
      Console.ReadLine();
      
    }
    
    private static void PrintTokens(TextTokens tokens, int count)
    {
      var sb = new StringBuilder();
      List<IntString> result = new List<IntString>();
      int i = 0;
      foreach (vartoken in tokens.Tokens)
      {
        int j = 0;
        for (j = 0; j<i; j++)
        {
          if (result[j].getToken() == token)
          {
            result[j].addValue();
            break;
          }
        }
        if (j == i)
        {
          result.Add(new IntString(token));
          i++;
        }
        sb.AppendLine(token);
      }
      var sorted = result.OrderByDescending(x => x.getCount());
      for (i = 0; i<count; i++)
      {
        Console.WriteLine(sorted.ElementAt(i).getToken());
      }
      Console.WriteLine("-----------------------");
      Console.WriteLine(sb.toString());
    }
    
    private static void PrintTokens2(TextTokens tokens)
    {
      var sb = new StringBuilder();
      foreach (vartoken in tokens.Tokens)
      {
        sb.AppendLine(token);
      }
      Console.WriteLine(sb.toString());
    }
  }
}

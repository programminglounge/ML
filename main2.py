from nltk.tokenize import sent_tokenize
from spacy.lang.en import English
import spacy

text = '''
Joe waited for the train. The train was late.
Mary and Sam took the bus.
I looked for Mary and Sam at the bus station.
'''

token_txt = sent_tokenize(text)

from nltk.corpus import wordnet as wn

def get_lemma(word):
  lemma = wn.morphy(word)
  if lemma is None:
    return word
  else:
    return lemma
  
spacy.load("en_core_web_sm")
parser = English()

en_stop = set(nltk.corpus.stopwords.words('english'))

def my_tokenize(text):
  lda_tokens = []
  tokens = parser(text)
  for token in tokens:
    if token.orth_.isspace():
      continue
    elif token.like_url:
      lda_tokens.append('URL')
    elif token.orth_.startswith('@'):
      lda_tokens.append('SCREEN_NAME')
    else:
      lda_tokens.append(token.lower_)
  return lda_tokens

def prepare_text_for_lda(text):
  tokens = my_tokenize(text)
  tokens = [token for token in tokens if len(token)>=3]
  tokens = [token for token in tokens if token not in en_stop]
  tokens = [get_lemma(token) for token in tokens]
  return tokens

text_data = []
for line in token_text:
  tokens = prepare_text_for_lda(line)
  print(tokens)
  text_data.append(tokens)
      
   

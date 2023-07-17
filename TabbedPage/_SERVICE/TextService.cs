using PHOTEX.MODEL.DOMAIN;
using PHOTEX.MODEL.REPOSITORY;
using PHOTEX.SERVICE;

namespace PHOTEX._SERVICE
{
    public class TextService : ITextService<Text>
    {
        //properties
        private readonly ITextRepository<Text> _textRepository;
        
        //constructors
        public TextService(ITextRepository<Text> p_textRepository)
        {
            this._textRepository = p_textRepository;
        }
        
        //methods
        public IEnumerable<Text> allTexts()
        {
            return _textRepository.readAll();
        }
        
        public async Task saveTextLocally(Text text) 
        {
            _textRepository.save(text);
        }

        public void copyText(Text text)
        {
            Clipboard.SetTextAsync(text.content);
        }
    }
}

lexer grammar CeciliaLexer;

channels {
	COMMENTS_CHANNEL
}

SingleLineComment:
	'//' InputCharacter* -> channel(COMMENTS_CHANNEL);
MultiLineComment: '/*' .*? '*/' -> channel(COMMENTS_CHANNEL);

Whitespaces: (Whitespace | NewLine)+ -> channel(HIDDEN);

BoolKeyword: 'bool';
CharKeyword: 'char';
StringKeyword: 'string';
ObjectKeyword: 'object';
ByteKeyword: 'byte';
ShortKeyword: 'short';
IntKeyword: 'int';
LongKeyword: 'long';
UbyteKeyword: 'ubyte';
UshortKeyword: 'ushort';
UintKeyword: 'uint';
UlongKeyword: 'ulong';
HalfKeyword: 'half';
FloatKeyword: 'float';
DoubleKeyword: 'double';
DecimalKeyword: 'decimal';
NamespaceKeyword: 'namespace';
PublicKeyword: 'public';
PrivateKeyword: 'private';
InternalKeyword: 'internal';
UsingKeyword: 'using';
VarKeyword: 'var';
ConstKeyword: 'const';
SwitchKeyword: 'switch';
LoopKeyword: 'loop';
MacroKeyword: 'macro';
TrueKeyword: 'true';
FalseKeyword: 'false';
DefaultKeyword: 'default';
ReturnKeyword: 'return';

LParen: '(';
RParen: ')';
LBracket: '[';
RBracket: ']';
LBrace: '{';
RBrace: '}';
Exclamation: '!';
Dollar: '$';
Parcent: '%';
Caret: '^';
Ampersand: '&';
Asterisk: '*';
Minus: '-';
Plus: '+';
Equals: '=';
Bar: '|';
Backslash: '\\';
Colon: ':';
SemiColon: ';';
DoubleQuote: '"';
SingleQuote: '\'';
LessThan: '<';
GreaterThan: '>';
Comma: ',';
Dot: '.';
Question: '?';
Hash: '#';
Slash: '/';

BarBar: '||';
AmpAmp: '&&';
MinusMinus: '--';
PlusPlus: '++';
QuestionQuestion: '??';
EqualsEquals: '==';
ExclamationEquals: '!=';
Arrow: '=>';
LessThanEqual: '<=';
GreaterThanEqual: '>=';
LessThanLessThan: '<<';
GreaterThanGreaterThan: '>>';
PlusEqual: '+=';
MinusEqual: '-=';
AsteriskEqual: '*=';
SlashEqual: '/=';
BarEqual: '|=';
CaretEqual: '^=';

LessThanLessThanEqual: '<<=';
GreaterThanGreaterThanEqual: '>>=';

IntegerLiteral: [0-9]+ IntegerTypeSuffix?;
FloatingLiteral:
	[0-9]* Dot [0-9]+ ExponentPart? [FfDdMm]?
	| [0-9]+ ([FfDdMm] | ExponentPart [FfDdMm]?);
CharacterLiteral:
	SingleQuote (~['\\\r\n\u0085\u2028\u2029] | CommonCharacter) SingleQuote;
RegularString:
	DoubleQuote (~["\\\r\n\u0085\u2028\u2029] | CommonCharacter)* DoubleQuote;

fragment IntegerTypeSuffix: [1L]? [uU]| [uU]| [1L];
fragment ExponentPart: [eE] ('+' | '-')? [0-9]+;

Identifier: Letter LetterOrDigit*;

fragment Letter: [a-zA-Z$_];

fragment LetterOrDigit: [a-zA-Z0-9$_];

fragment InputCharacter: ~[\r\n\u0085\u2028\u2029];

fragment Whitespace: UnicodeCategoryZs;

fragment UnicodeCategoryZs:
	'\u0020'
	| '\u00A0'
	| '\u1680'
	| '\u2000'
	| '\u2001'
	| '\u2002'
	| '\u2003'
	| '\u2004'
	| '\u2005'
	| '\u2006'
	| '\u2007'
	| '\u2008'
	| '\u2009'
	| '\u202F'
	| '\u205F'
	| '\u3000';

fragment NewLine:
	'\r\n'
	| '\r'
	| '\n'
	| '\u0085'
	| '\u2028'
	| '\u2029';

fragment CommonCharacter:
	SimpleEscapeSequence
	| HexEscapeSequence
	| UnicodeEscapeSequence;

fragment SimpleEscapeSequence:
	'\\\''
	| '\\"'
	| '\\\\'
	| '\\0'
	| '\\a'
	| '\\b'
	| '\\f'
	| '\\n'
	| '\\r'
	| '\\t'
	| '\\v';

fragment HexEscapeSequence:
	'\\x' HexDigit
	| '\\x' HexDigit HexDigit
	| '\\x' HexDigit HexDigit HexDigit
	| '\\x' HexDigit HexDigit HexDigit HexDigit;

fragment UnicodeEscapeSequence:
	'\\u' HexDigit HexDigit HexDigit HexDigit
	| '\\U' HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit;

fragment HexDigit: [0-9]| [a-f][A-F];
parser grammar Cecilia;

options {
	tokenVocab = CeciliaLexer;
}

program: using_directives? namespace_member_declarations? EOF;

using_directives: using_directive+;

using_directive: UsingKeyword qualified_identifier;

qualified_identifier: (Identifier) (Dot Identifier)*;

namespace_member_declarations: namespace_member_declaration+;

namespace_member_declaration:
	namespace_declaration
	| type_declaration;

namespace_declaration:
	NamespaceKeyword qualified_identifier namespace_body SemiColon?;

namespace_body: LBrace using_directives? RBrace;

type_declaration: all_member_modifiers? (member_declaration);

all_member_modifiers: all_member_modifier+;

all_member_modifier:
	PublicKeyword
	| PrivateKeyword
	| InternalKeyword;

member_declaration: constant_declaration | variable_declaration;

constant_declaration: ConstKeyword variable_declarators;

variable_declaration: VarKeyword variable_declarators;

macro_declaration: MacroKeyword variable_declarators;

variable_declarators:
	variable_declarator (Comma variable_declarator)*;

variable_declarator: Identifier (Colon type)? Equals expression;

type: embedded_type | user_definition_type;

embedded_type:
	number_type
	| other_base_type
	| special_support_type;

number_type:
	integral_number_type
	| floating_number_type
	| DecimalKeyword;

integral_number_type:
	ByteKeyword
	| UbyteKeyword
	| ShortKeyword
	| UshortKeyword
	| IntKeyword
	| UintKeyword
	| LongKeyword
	| UlongKeyword;

floating_number_type:
	HalfKeyword
	| FloatKeyword
	| DoubleKeyword;

other_base_type: BoolKeyword | CharKeyword;

special_support_type: StringKeyword | ObjectKeyword;

user_definition_type: qualified_identifier;

expression: (
		function_expression
		| assignment_expression
		| switch_expression
		| loop_expression
		| return_expression
	) SemiColon?;

assignment_expression:
	unary_expression assignment_operator expression;

unary_expression:
	primary_expression
	| Plus unary_expression
	| Minus unary_expression
	| PlusPlus unary_expression
	| MinusMinus unary_expression
	| Ampersand unary_expression
	| Asterisk unary_expression;

primary_expression: primary_expression_start;

primary_expression_start:
	literal
	| Identifier
	| LParen expression RParen;

assignment_operator:
	Equals
	| PlusEqual
	| MinusEqual
	| AsteriskEqual
	| SlashEqual
	| BarEqual
	| CaretEqual;

// Loop expression
loop_expression: LoopKeyword loop_condition? block;

loop_condition:
	LParen function_paramter expression RParen
	| LParen expression RParen;

// return expression
return_expression: ReturnKeyword expression?;

// Switch expression
switch_expression:
	SwitchKeyword LParen expression RParen LBrace switch_section* RBrace;

switch_section: switch_label expression_list;

switch_label: expression Colon | DefaultKeyword Colon;

// Literal
literal:
	boolean_literal
	| string_literal
	| IntegerLiteral
	| FloatingLiteral
	| CharacterLiteral;

// true or false
boolean_literal: TrueKeyword | FalseKeyword;

// String literal
string_literal: RegularString;

// Function definition expression.
function_expression: function_signature Arrow function_body;

function_signature:
	LParen RParen
	| LParen function_parameter_list RParen
	| Identifier;

function_parameter_list:
	function_paramter (',' function_paramter)*;

function_paramter: Identifier (Colon type)?;

function_body: expression | block;

block: LBrace expression_list? RBrace;

expression_list: expression+;
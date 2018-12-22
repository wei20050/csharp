CNWTEPRGs`�
s ��Ϫ��ͻ��s s s s s          � <                                                            �                                  s��4,s �ú���λ��s s s s s         VHA1\                                              SHA1                                                                                   sN��s �����Э��s s s s s          ���@                                                 0  	     $   ����_sha1_js    var hexcase=1;var b64pad="=";function hex_sha1(s){return rstr2hex(rstr_sha1(str2rstr_utf8(s)));}
function b64_sha1(s){return rstr2b64(rstr_sha1(str2rstr_utf8(s)));}
function any_sha1(s,e){return rstr2any(rstr_sha1(str2rstr_utf8(s)),e);}
function hex_hmac_sha1(k,d)
{return rstr2hex(rstr_hmac_sha1(str2rstr_utf8(k),str2rstr_utf8(d)));}
function b64_hmac_sha1(k,d)
{return rstr2b64(rstr_hmac_sha1(str2rstr_utf8(k),str2rstr_utf8(d)));}
function any_hmac_sha1(k,d,e)
{return rstr2any(rstr_hmac_sha1(str2rstr_utf8(k),str2rstr_utf8(d)),e);}
function sha1_vm_test()
{return hex_sha1("abc").toLowerCase()=="a9993e364706816aba3e25717850c26c9cd0d89d";}
function rstr_sha1(s)
{return binb2rstr(binb_sha1(rstr2binb(s),s.length*8));}
function rstr_hmac_sha1(key,data)
{var bkey=rstr2binb(key);if(bkey.length>16)bkey=binb_sha1(bkey,key.length*8);var ipad=Array(16),opad=Array(16);for(var i=0;i<16;i++)
{ipad[i]=bkey[i]^0x36363636;opad[i]=bkey[i]^0x5C5C5C5C;}
var hash=binb_sha1(ipad.concat(rstr2binb(data)),512+data.length*8);return binb2rstr(binb_sha1(opad.concat(hash),512+160));}
function rstr2hex(input)
{try{hexcase}catch(e){hexcase=0;}
var hex_tab=hexcase?"0123456789ABCDEF":"0123456789abcdef";var output="";var x;for(var i=0;i<input.length;i++)
{x=input.charCodeAt(i);output+=hex_tab.charAt((x>>>4)&0x0F)
+hex_tab.charAt(x&0x0F);}
return output;}
function rstr2b64(input)
{try{b64pad}catch(e){b64pad='';}
var tab="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";var output="";var len=input.length;for(var i=0;i<len;i+=3)
{var triplet=(input.charCodeAt(i)<<16)|(i+1<len?input.charCodeAt(i+1)<<8:0)|(i+2<len?input.charCodeAt(i+2):0);for(var j=0;j<4;j++)
{if(i*8+j*6>input.length*8)output+=b64pad;else output+=tab.charAt((triplet>>>6*(3-j))&0x3F);}}
return output;}
function rstr2any(input,encoding)
{var divisor=encoding.length;var remainders=Array();var i,q,x,quotient;var dividend=Array(Math.ceil(input.length/2));for(i=0;i<dividend.length;i++)
{dividend[i]=(input.charCodeAt(i*2)<<8)|input.charCodeAt(i*2+1);}
while(dividend.length>0)
{quotient=Array();x=0;for(i=0;i<dividend.length;i++)
{x=(x<<16)+dividend[i];q=Math.floor(x/divisor);x-=q*divisor;if(quotient.length>0||q>0)
quotient[quotient.length]=q;}
remainders[remainders.length]=x;dividend=quotient;}
var output="";for(i=remainders.length-1;i>=0;i--)
output+=encoding.charAt(remainders[i]);var full_length=Math.ceil(input.length*8/(Math.log(encoding.length)/Math.log(2)))
for(i=output.length;i<full_length;i++)
output=encoding[0]+output;return output;}
function str2rstr_utf8(input)
{var output="";var i=-1;var x,y;while(++i<input.length)
{x=input.charCodeAt(i);y=i+1<input.length?input.charCodeAt(i+1):0;if(0xD800<=x&&x<=0xDBFF&&0xDC00<=y&&y<=0xDFFF)
{x=0x10000+((x&0x03FF)<<10)+(y&0x03FF);i++;}
if(x<=0x7F)
output+=String.fromCharCode(x);else if(x<=0x7FF)
output+=String.fromCharCode(0xC0|((x>>>6)&0x1F),0x80|(x&0x3F));else if(x<=0xFFFF)
output+=String.fromCharCode(0xE0|((x>>>12)&0x0F),0x80|((x>>>6)&0x3F),0x80|(x&0x3F));else if(x<=0x1FFFFF)
output+=String.fromCharCode(0xF0|((x>>>18)&0x07),0x80|((x>>>12)&0x3F),0x80|((x>>>6)&0x3F),0x80|(x&0x3F));}
return output;}
function str2rstr_utf16le(input)
{var output="";for(var i=0;i<input.length;i++)
output+=String.fromCharCode(input.charCodeAt(i)&0xFF,(input.charCodeAt(i)>>>8)&0xFF);return output;}
function str2rstr_utf16be(input)
{var output="";for(var i=0;i<input.length;i++)
output+=String.fromCharCode((input.charCodeAt(i)>>>8)&0xFF,input.charCodeAt(i)&0xFF);return output;}
function rstr2binb(input)
{var output=Array(input.length>>2);for(var i=0;i<output.length;i++)
output[i]=0;for(var i=0;i<input.length*8;i+=8)
output[i>>5]|=(input.charCodeAt(i/8)&0xFF)<<(24-i%32);return output;}
function binb2rstr(input)
{var output="";for(var i=0;i<input.length*32;i+=8)
output+=String.fromCharCode((input[i>>5]>>>(24-i%32))&0xFF);return output;}
function binb_sha1(x,len)
{x[len>>5]|=0x80<<(24-len%32);x[((len+64>>9)<<4)+15]=len;var w=Array(80);var a=1732584193;var b=-271733879;var c=-1732584194;var d=271733878;var e=-1009589776;for(var i=0;i<x.length;i+=16)
{var olda=a;var oldb=b;var oldc=c;var oldd=d;var olde=e;for(var j=0;j<80;j++)
{if(j<16)w[j]=x[i+j];else w[j]=bit_rol(w[j-3]^w[j-8]^w[j-14]^w[j-16],1);var t=safe_add(safe_add(bit_rol(a,5),sha1_ft(j,b,c,d)),safe_add(safe_add(e,w[j]),sha1_kt(j)));e=d;d=c;c=bit_rol(b,30);b=a;a=t;}
a=safe_add(a,olda);b=safe_add(b,oldb);c=safe_add(c,oldc);d=safe_add(d,oldd);e=safe_add(e,olde);}
return Array(a,b,c,d,e);}
function sha1_ft(t,b,c,d)
{if(t<20)return(b&c)|((~b)&d);if(t<40)return b^c^d;if(t<60)return(b&c)|(b&d)|(c&d);return b^c^d;}
function sha1_kt(t)
{return(t<20)?1518500249:(t<40)?1859775393:(t<60)?-1894007588:-899497514;}
function safe_add(x,y)
{var lsw=(x&0xFFFF)+(y&0xFFFF);var msw=(x>>16)+(y>>16)+(lsw>>16);return(msw<<16)|(lsw&0xFFFF);}
function bit_rol(num,cnt)
{return(num<<cnt)|(num>>>(32-cnt));}     s�I<s ������s s s s s s          Q0���                                          �
 ?�   e        1           9   krnlnd09f2340818511d396f6aaf844c7e32553ϵͳ����֧�ֿ�8   specA512548E76954B6E92C21055517615B031���⹦��֧�ֿ�                     	@Y            ����1          F                F `X �W �V �U   	     �   _�����ӳ���"   ���ڱ��ӳ����з�����ģ���ʼ������                       6                      p   j ��      #   �ڳ�ʼ������ִ����Ϻ���ò��Դ��� 6j              ���Ը���������Ҫ���������� ֵ 6          	           _��ʱ�ӳ���                           i   �   �            {           �  j              6! ��          6#   AKIDZfbOA78asKUYBcXFrJD0a1ICvR98JM    1480932292;1481012292 j              6!F ��          6V   get\n/testfile\n\nhost=testbucket-125000000.cn-north.myqcloud.com&range=bytes%3d0-3\n j    ��      �   �������ӳ����������Գ����ã����ڿ��������Ի�������Ч�����뷢������ǰ����ϵͳ�Զ���գ��뽫�����������Ե���ʱ������ڱ��ӳ����С� ***ע�ⲻҪ�޸ı��ӳ�������ơ�����������ֵ���͡� 6j    ��          6  	     �	   HMAC_SHA1       Z    % %5 %       ,      0     ��_script     1     ��_result       �   ��_������     6   �
%* %            �   ��_key       �   ��_str         ,   _   �                     ,   _     �   �   �   �      �   8  jG              8 %7   scriptcontrol jR              8 %7	   Language    JScript jV              8 %7   AddCode 	 j4               68 %7!T              8 %7   Eval !               6   hex_hmac_sha1(' 8�
%7   ',' 8* %7   ') j               6!d              8 %7  	     �   SHA1       <   J %K %          0     ��_script     1     ��_result        H %         �   ��_str         ,   _   �   �                  ,   	  _   �   �   �      �   #  jG              8J %7   scriptcontrol jR              8J %7	   Language    JScript jV              8J %7   AddCode 	 j4               68K %7!T              8J %7   Eval !               6   hex_sha1(' 8H %7   ') j               6!d              8K %7                                                        s��CJs �׽��»��<s s s s s                                                                        s��}Ds ��¥������s s s s s                                                               s�K�s �ɳ����գ��s s s s s         .��Q                                           1   C:\Users\Administrator\Desktop\�½��ļ���\SHA1.ec                        ����s���s 	�൴��ƻ��;s 	s 	s 	s 	s         �3                                                       �              	 �  � �   �   ss s                                 	                                                       
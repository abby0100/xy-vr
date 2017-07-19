package com.good.great.test01;

import android.app.Activity;
import android.os.Bundle;
import android.webkit.WebView;
import android.widget.Toast;

public class WebViewActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        showWebView();
        showWebView2();
    }

    private void showWebView2() {
        Toast.makeText(WebViewActivity.this, "showWebView2", Toast.LENGTH_LONG).show();
        WebView webView = (WebView) findViewById(R.id.webview);
        String mUrl = "http://www.baidu.com";
        webView.loadUrl(mUrl);
        webView.getSettings().setJavaScriptEnabled(true);
        webView.setWebViewClient(new WebViewClient());
    }

    private void showWebView() {
        Toast.makeText(WebViewActivity.this, "showWebView", Toast.LENGTH_LONG).show();
        WebView webView = new WebView(WebViewActivity.this);
        String mUrl = "http://www.baidu.com";
        webView.loadUrl(mUrl);
        webView.getSettings().setJavaScriptEnabled(true);
        webView.setWebViewClient(new WebViewClient());
    }

    private class WebViewClient extends android.webkit.WebViewClient {
        @Override
        public boolean shouldOverrideUrlLoading(WebView view, String url) {
            //这里实现的目标是在网页中继续点开一个新链接，还是停留在当前程序中
            view.loadUrl(url);
            return super.shouldOverrideUrlLoading(view, url);
        }
    }
}


